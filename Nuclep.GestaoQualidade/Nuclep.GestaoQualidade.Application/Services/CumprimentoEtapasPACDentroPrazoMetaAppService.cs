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
    public class CumprimentoEtapasPACDentroPrazoMetaAppService : ICumprimentoEtapasPACDentroPrazoMetaAppService
    {
        private readonly ICumprimentoEtapasPACDentroPrazoMetaDomainService _cumprimentoEtapasPACDentroPrazoMetaDomainService;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;



        public CumprimentoEtapasPACDentroPrazoMetaAppService(
            ICumprimentoEtapasPACDentroPrazoMetaDomainService cumprimentoEtapasPACDentroPrazoMetaDomainService, 
            IMapper mapper, IUsuarioSession usuarioSession, ILogTabelaRepository logTabelaRepository, ILogCrudRepository logCrudRepository)
        {
            _cumprimentoEtapasPACDentroPrazoMetaDomainService = cumprimentoEtapasPACDentroPrazoMetaDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
        }

        public async Task<CumprimentoEtapasPACDentroPrazoMetaResponseDTO> AddAsync(CumprimentoEtapasPACDentroPrazoMetaRequestDTO request)
        {
            var model = _mapper.Map<CumprimentoEtapasPACDentroPrazoMeta>(request);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            model.DataHoraCadastro = DateTime.Now;
            model.UsuarioCadastro = await _usuarioSession.GetUsuarioLogado();
            model.IsAtivo = true;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_CumprimentoEtapasPACDentroPrazoMeta");

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

                    var result = await _cumprimentoEtapasPACDentroPrazoMetaDomainService.AddAsync(model);

                    transaction.Complete();

                    return _mapper.Map<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>(result);

                }
                catch (Exception ex)
                {

                    throw;
                }


            }


        }
        public async Task<CumprimentoEtapasPACDentroPrazoMetaResponseDTO> UpdateAsync(long id, CumprimentoEtapasPACDentroPrazoMetaRequestDTO request)
        {
            var model = _mapper.Map<CumprimentoEtapasPACDentroPrazoMeta>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_CumprimentoEtapasPACDentroPrazoMeta");

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

                    var result = await _cumprimentoEtapasPACDentroPrazoMetaDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }

               

        }

        public async Task<CumprimentoEtapasPACDentroPrazoMetaResponseDTO> DeleteAsync(long id)
        {
            var model = await _cumprimentoEtapasPACDentroPrazoMetaDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                Usuario = usuarioLogado,
                LogTipo = LogTipo.Cadastrado,
                LogTabela = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_CumprimentoEtapasPACDentroPrazoMeta".ToLower()).Result,
                IdReferencia = model.Id,
                Descricao = $"Meta Aderência Programação Mensal de valor {model.Meta} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _cumprimentoEtapasPACDentroPrazoMetaDomainService.DeleteAsync(id);

            return _mapper.Map<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>(result);

        }

        public async Task<CumprimentoEtapasPACDentroPrazoMetaResponseDTO> GetByIdAsync(long id)
        {
            var result = await _cumprimentoEtapasPACDentroPrazoMetaDomainService.GetByIdAsync(id);
            return _mapper.Map<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>(result);
        }


        public async Task<List<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>> GetAllAsync()
        {
            var result = await _cumprimentoEtapasPACDentroPrazoMetaDomainService.GetAllAsync();

            return _mapper.Map<List<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>>(result);
        }

        public async Task<List<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _cumprimentoEtapasPACDentroPrazoMetaDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>>(result);
        }

        private List<LogCrud> Logar(CumprimentoEtapasPACDentroPrazoMetaRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            //Log de diferenças
            if (request.Id != 0)
            {
                CumprimentoEtapasPACDentroPrazoMeta requestOld = _mapper.Map<CumprimentoEtapasPACDentroPrazoMeta>(GetByIdAsync(request.Id).Result);
                CumprimentoEtapasPACDentroPrazoMeta requestNew = _mapper.Map<CumprimentoEtapasPACDentroPrazoMeta>(request);

                logs.AddRange(from diff in ViewModelHelper.PublicInstancePropertiesEqual(requestOld, requestNew)
                              where !diff.Key.EndsWith("Id")
                              let propCamelcase =
                                                System.Text.RegularExpressions.Regex.Replace(diff.Key, "([A-Z])", " $1",
                                                    System.Text.RegularExpressions.RegexOptions.Compiled).Trim()
                              select new LogCrud(usuarioLogado
                              , LogTipo.Alterado
                              , _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower().Equals(tabela.ToLower())).Result
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
                    logs.Add(new LogCrud(usuarioLogado, LogTipo.Cadastrado,
                   _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower().Equals(tabela.ToLower())).Result, null,
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
            _cumprimentoEtapasPACDentroPrazoMetaDomainService.Dispose();
        }


    }
}
