using AutoMapper;
using Microsoft.AspNetCore.Http;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Helpers;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Application.Interfaces.Sistema;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Nuclep.GestaoQualidade.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService _UsuarioDomainService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IUsuarioSession _usuarioSession;


        public UsuarioAppService(
            IUsuarioDomainService UsuarioDomainService,
            IMapper mapper,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IUsuarioSession usuarioSession)
        {
            _UsuarioDomainService = UsuarioDomainService;
            _mapper = mapper;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _usuarioSession = usuarioSession;
        }

        public async Task<UsuarioResponseDTO> AddAsync(string nomeAD)
        {
            Usuario usuario = new Usuario();

            string login = nomeAD;

            var usuarioAD = ActiveDirectoryHelper.GetUserDetails(login);

            var novousuario = new Usuario();

            novousuario.Nome = usuarioAD.GivenName == null ? nomeAD : usuarioAD.GivenName;
            novousuario.NomeAD = nomeAD;
            novousuario.IsAtivo = false;
            novousuario.DataHoraCadastro = DateTime.Now;
            novousuario.PerfilSistema = Enums.NaoInformado;
            novousuario.UsuarioCadastro = await _UsuarioDomainService.GetByIdAsync(1);

            var usuarioAdm = _UsuarioDomainService.GetByIdAsync(1).Result; /*AdminQualidade*/

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioAdm.Id,
                UsuarioNome = usuarioAdm.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "sys_usuario").Result.Id,
                IdReferencia = novousuario.Id,
                Descricao = $"Usuário {novousuario.Nome} cadastrado no sistema de forma automática."
            };

            // Inicia uma transação
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    // Adiciona o novo usuário
                    var result = await _UsuarioDomainService.AddAsync(novousuario);

                    // Adiciona o log de CRUD
                    await _logCrudRepository.AddAsync(logCrud);

                    // Completa a transação
                    transaction.Complete();

                    return _mapper.Map<UsuarioResponseDTO>(result);
                }
                catch
                {
                    // Se ocorrer um erro, a transação será revertida
                    throw;
                }
            }
        }
        public async Task<UsuarioResponseDTO> UpdateAsync(long id, UsuarioRequestDTO request)
        {
            var model = _mapper.Map<Usuario>(request);

            model.Id = id;

            var logs = Logar(request, "sys_usuario");


            // Inicia uma transação
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    foreach (var item in await logs)
                    {   
                        item.IdReferencia = id;
                        await _logCrudRepository.AddAsync(item);
                    }

                    var result = await _UsuarioDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<UsuarioResponseDTO>(result);

                }
                catch (Exception ex)
                {

                    throw;
                }
            }


        }

        public async Task<UsuarioResponseDTO> DeleteAsync(long id)
        {
            var usuario = await _UsuarioDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var usuarioAdm = _UsuarioDomainService.GetByIdAsync(1).Result; /*AdminQualidade*/


            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioAdm.Id,
                UsuarioNome = usuarioAdm.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "sys_usuario").Result.Id,
                IdReferencia = usuario.Id,
                Descricao = $"Usuário {usuario.Nome} excluído no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            // Inicia uma transação
            using(var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    // Adiciona o log de CRUD
                    await _logCrudRepository.AddAsync(logCrud);

                    var result = await _UsuarioDomainService.DeleteAsync(id);

                    // Completa a transação
                    transaction.Complete();

                    return _mapper.Map<UsuarioResponseDTO>(result);


                }
                catch (Exception)
                {

                    throw;
                }
            }

           

        }
        public async Task<UsuarioResponseDTO> GetByIdAsync(long id)
        {
            var result = await _UsuarioDomainService.GetByIdAsync(id);
            return _mapper.Map<UsuarioResponseDTO>(result);
        }  
        
        public async Task<UsuarioResponseDTO> GetByNameAsync(string nome)
        {
            var result = await _UsuarioDomainService.GetByNameAsync(nome);
            return _mapper.Map<UsuarioResponseDTO>(result);
        }
         
        public async Task<UsuarioResponseDTO> GetByLoginAsync(string login)
        {
            var result = await _UsuarioDomainService.GetByLoginAsync(login);
            return _mapper.Map<UsuarioResponseDTO>(result);
        }

        public async Task<List<UsuarioResponseDTO>> GetByNameListAsync(string nome)
        {
            var result = await _UsuarioDomainService.GetByNameListAsync(nome);
            return _mapper.Map<List<UsuarioResponseDTO>>(result);
        }

        public async Task<List<UsuarioResponseDTO>> GetAllAsync()
        {
            var result = await _UsuarioDomainService.GetAllAsync();
            return _mapper.Map<List<UsuarioResponseDTO>>(result);
        }

        public async Task<List<UsuarioResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _UsuarioDomainService.GetAllAtivosAsync();
            return _mapper.Map<List<UsuarioResponseDTO>>(result);
        }

        public async Task<bool> ExisteUsuario(string nomeAD)
        {
            var result = await _UsuarioDomainService.ExisteUsuario(nomeAD);

            //Lógica para criação de usuário

            if (!result)
            {
                await AddAsync(nomeAD);
            }


            return result;
        }


        private async Task<List<LogCrud>> Logar(UsuarioRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                Usuario requestOld = _mapper.Map<Usuario>(GetByIdAsync(request.Id).Result);
                Usuario requestNew = _mapper.Map<Usuario>(request);

                logs.AddRange(from diff in ViewModelHelper.PublicInstancePropertiesEqual(requestOld, requestNew)
                              where !diff.Key.EndsWith("Id")
                              let propCamelcase =
                                                System.Text.RegularExpressions.Regex.Replace(diff.Key, "([A-Z])", " $1",
                                                    System.Text.RegularExpressions.RegexOptions.Compiled).Trim()
                              select new LogCrud(usuarioLogado.Id, usuarioLogado.Nome
                              , LogTipo.Alterado
                              , logTabela.Id
                              , logTabela.Nome
                              , propCamelcase,
                              (diff.Value.Item1 == null || string.IsNullOrEmpty(diff.Value.Item1.ToString())
                              ? "'sem dado'"
                              : diff.Value.Item1.ToString())
                              ,
                              (diff.Value.Item2 == null || string.IsNullOrEmpty(diff.Value.Item2.ToString())
                                                    ? "'sem dado'"
                                                    : diff.Value.Item2.ToString())
                                                ));
            }
            else
            {
                try
                {
                    logs.Add(new LogCrud(usuarioLogado.Id, usuarioLogado.Nome, LogTipo.Cadastrado, logTabela.Id, logTabela.Nome, null, null, null));
                }
                catch (Exception ex)
                {

                    throw;
                }

            }

            return logs;
        }


        public void Dispose()
        {
            _UsuarioDomainService.Dispose();
        }

    }
}
