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
    public class LocalidadeAppService : ILocalidadeAppService
    {
        private readonly ILocalidadeDomainService _localidadeDomainService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IUsuarioSession _usuarioSession;


        public LocalidadeAppService(
            ILocalidadeDomainService UsuarioDomainService,
            IMapper mapper,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IUsuarioSession usuarioSession)
        {
            _localidadeDomainService = UsuarioDomainService;
            _mapper = mapper;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _usuarioSession = usuarioSession;
        }

        public async Task<LocalidadeResponseDTO> AddAsync(LocalidadeRequestDTO request)
        {
            Usuario usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            request.UsuarioCadastroId = usuarioLogado.Id;
            request.UsuarioCadastroName = usuarioLogado.Nome;
            request.DataHoraCadastro = DateTime.Now;

            var model = _mapper.Map<Localidade>(request);

           

            var logs = Logar(request, "sys_usuario");


            // Inicia uma transação
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                   
                    var result = await _localidadeDomainService.AddAsync(model);

                    foreach (var item in await logs)
                    {
                        item.IdReferencia = result.Id;
                        await _logCrudRepository.AddAsync(item);
                    }

                    transaction.Complete();

                    return _mapper.Map<LocalidadeResponseDTO>(result);

                }
                catch (Exception ex)
                {

                    throw;
                }
            }

        }
        public async Task<LocalidadeResponseDTO> UpdateAsync(long id, LocalidadeRequestDTO request)
        {
            var model = _mapper.Map<Localidade>(request);

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

                    var result = await _localidadeDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<LocalidadeResponseDTO>(result);

                }
                catch (Exception ex)
                {

                    throw;
                }
            }


        }

        public async Task<LocalidadeResponseDTO> DeleteAsync(long id)
        {
            var usuario = await _localidadeDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
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

                    var result = await _localidadeDomainService.DeleteAsync(id);

                    // Completa a transação
                    transaction.Complete();

                    return _mapper.Map<LocalidadeResponseDTO>(result);


                }
                catch (Exception)
                {

                    throw;
                }
            }

           

        }
        public async Task<LocalidadeResponseDTO> GetByIdAsync(long id)
        {
            var result = await _localidadeDomainService.GetByIdAsync(id);
            return _mapper.Map<LocalidadeResponseDTO>(result);
        }  
        
        public async Task<LocalidadeResponseDTO> GetByNameAsync(string nome)
        {
            var result = await _localidadeDomainService.GetByNameAsync(nome);
            return _mapper.Map<LocalidadeResponseDTO>(result);
        }
         
        public async Task<LocalidadeResponseDTO> GetByLoginAsync(string login)
        {
            var result = await _localidadeDomainService.GetByLoginAsync(login);
            return _mapper.Map<LocalidadeResponseDTO>(result);
        }

        public async Task<List<LocalidadeResponseDTO>> GetByNameListAsync(string nome)
        {
            var result = await _localidadeDomainService.GetByNameListAsync(nome);
            return _mapper.Map<List<LocalidadeResponseDTO>>(result);
        }

        public async Task<List<LocalidadeResponseDTO>> GetAllAsync()
        {
            var result = await _localidadeDomainService.GetAllAsync();
            return _mapper.Map<List<LocalidadeResponseDTO>>(result);
        }

        public async Task<List<LocalidadeResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _localidadeDomainService.GetAllAtivosAsync();
            return _mapper.Map<List<LocalidadeResponseDTO>>(result);
        }

      


        private async Task<List<LogCrud>> Logar(LocalidadeRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                Localidade requestOld = _mapper.Map<Localidade>(GetByIdAsync(request.Id).Result);
                Localidade requestNew = _mapper.Map<Localidade>(request);

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
            _localidadeDomainService.Dispose();
        }

    }
}
