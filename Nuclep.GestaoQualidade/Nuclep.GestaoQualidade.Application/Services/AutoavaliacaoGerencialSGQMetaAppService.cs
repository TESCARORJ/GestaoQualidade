using AutoMapper;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Helpers;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Application.Interfaces.Sistema;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using Nuclep.GestaoQualidade.Domain.Services;
using Nuclep.GestaoQualidade.SqlServer.Repositories;
using System.Transactions;

namespace Nuclep.GestaoQualidade.Application.Services
{
    public class AutoavaliacaoGerencialSGQMetaAppService : IAutoavaliacaoGerencialSGQMetaAppService
    {
        private readonly IAutoavaliacaoGerencialSGQMetaDomainService _autoavaliacaoGerencialSGQMetaDomainService;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;



        public AutoavaliacaoGerencialSGQMetaAppService(
            IAutoavaliacaoGerencialSGQMetaDomainService autoavaliacaoGerencialSGQMetaDomainService, 
            IMapper mapper, IUsuarioSession usuarioSession, ILogTabelaRepository logTabelaRepository, ILogCrudRepository logCrudRepository)
        {
            _autoavaliacaoGerencialSGQMetaDomainService = autoavaliacaoGerencialSGQMetaDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
        }

        public async Task<AutoavaliacaoGerencialSGQMetaResponseDTO> AddAsync(AutoavaliacaoGerencialSGQMetaRequestDTO request)
        {
            var model = _mapper.Map<AutoavaliacaoGerencialSGQMeta>(request);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            model.DataHoraCadastro = DateTime.Now;
            model.UsuarioCadastro = await _usuarioSession.GetUsuarioLogado();
            model.IsAtivo = true;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_AutoavaliacaoGerencialSGQMeta");

            // Inicia uma transação
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    foreach (var item in logs)
                    {
                        item.IdReferencia = model.Id;
                        await _logCrudRepository.AddAsync(item);
                    }

                    var result = await _autoavaliacaoGerencialSGQMetaDomainService.AddAsync(model);

                    transaction.Complete();

                    return _mapper.Map<AutoavaliacaoGerencialSGQMetaResponseDTO>(result);

                }
                catch (Exception ex)
                {

                    throw;
                }


            }


        }
        public async Task<AutoavaliacaoGerencialSGQMetaResponseDTO> UpdateAsync(long id, AutoavaliacaoGerencialSGQMetaRequestDTO request)
        {
            var model = _mapper.Map<AutoavaliacaoGerencialSGQMeta>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_AutoavaliacaoGerencialSGQMeta");

            // Inicia uma transação
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    foreach (var item in logs)
                    {
                        item.IdReferencia = model.Id;
                        await _logCrudRepository.AddAsync(item);
                    }

                    var result = await _autoavaliacaoGerencialSGQMetaDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<AutoavaliacaoGerencialSGQMetaResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }

               

        }

        public async Task<AutoavaliacaoGerencialSGQMetaResponseDTO> DeleteAsync(long id)
        {
            var model = await _autoavaliacaoGerencialSGQMetaDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_AutoavaliacaoGerencialSGQMeta".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $"Meta Aderência Programação Mensal de valor {model.Meta} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _autoavaliacaoGerencialSGQMetaDomainService.DeleteAsync(id);

            return _mapper.Map<AutoavaliacaoGerencialSGQMetaResponseDTO>(result);

        }

        public async Task<AutoavaliacaoGerencialSGQMetaResponseDTO> GetByIdAsync(long id)
        {
            var result = await _autoavaliacaoGerencialSGQMetaDomainService.GetByIdAsync(id);
            return _mapper.Map<AutoavaliacaoGerencialSGQMetaResponseDTO>(result);
        }


        public async Task<List<AutoavaliacaoGerencialSGQMetaResponseDTO>> GetAllAsync()
        {
            var result = await _autoavaliacaoGerencialSGQMetaDomainService.GetAllAsync();

            return _mapper.Map<List<AutoavaliacaoGerencialSGQMetaResponseDTO>>(result);
        }

        public async Task<List<AutoavaliacaoGerencialSGQMetaResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _autoavaliacaoGerencialSGQMetaDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<AutoavaliacaoGerencialSGQMetaResponseDTO>>(result);
        }

        private List<LogCrud> Logar(AutoavaliacaoGerencialSGQMetaRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            //Log de diferenças
            if (request.Id != 0)
            {
                AutoavaliacaoGerencialSGQMeta requestOld = _mapper.Map<AutoavaliacaoGerencialSGQMeta>(GetByIdAsync(request.Id).Result);
                AutoavaliacaoGerencialSGQMeta requestNew = _mapper.Map<AutoavaliacaoGerencialSGQMeta>(request);

                logs.AddRange(from diff in ViewModelHelper.PublicInstancePropertiesEqual(requestOld, requestNew)
                              where !diff.Key.EndsWith("Id")
                              let propCamelcase =
                                                System.Text.RegularExpressions.Regex.Replace(diff.Key, "([A-Z])", " $1",
                                                    System.Text.RegularExpressions.RegexOptions.Compiled).Trim()
                              select new LogCrud(usuarioLogado.Id, usuarioLogado.Nome
                              , LogTipo.Alterado
                              , _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower().Equals(tabela.ToLower())).Result.Id
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
                    logs.Add(new LogCrud(usuarioLogado.Id, usuarioLogado.Nome, LogTipo.Cadastrado,
                   _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower().Equals(tabela.ToLower())).Result.Id, null,
                   null, null));
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
            _autoavaliacaoGerencialSGQMetaDomainService.Dispose();
        }


    }
}
