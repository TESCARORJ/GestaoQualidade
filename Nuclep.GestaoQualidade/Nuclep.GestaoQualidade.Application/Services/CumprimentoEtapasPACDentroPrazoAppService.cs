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
using Nuclep.GestaoQualidade.Domain.Services;
using Nuclep.GestaoQualidade.SqlServer.Repositories;
using System.Globalization;
using System.Transactions;

namespace Nuclep.GestaoQualidade.Application.Services
{
    public class CumprimentoEtapasPACDentroPrazoAppService : ICumprimentoEtapasPACDentroPrazoAppService
    {
        private readonly ICumprimentoEtapasPACDentroPrazoDomainService _cumprimentoEtapasPACDentroPrazoDomainService;
        private readonly ICumprimentoEtapasPACDentroPrazoMetaDomainService _cumprimentoEtapasPACDentroPrazoMetaDomainService;
        private readonly ICumprimentoEtapasPACDentroPrazoMetaRepository _cumprimentoEtapasPACDentroPrazoMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly ICumprimentoEtapasPACDentroPrazoRepository _cumprimentoEtapasPACDentroPrazoRepository;



        public CumprimentoEtapasPACDentroPrazoAppService(
            ICumprimentoEtapasPACDentroPrazoDomainService cumprimentoEtapasPACDentroPrazoDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            ICumprimentoEtapasPACDentroPrazoMetaDomainService cumprimentoEtapasPACDentroPrazoMetaDomainService,
            ICumprimentoEtapasPACDentroPrazoMetaRepository cumprimentoEtapasPACDentroPrazoMetaRepository,
            ICumprimentoEtapasPACDentroPrazoRepository cumprimentoEtapasPACDentroPrazoRepository)
        {
            _cumprimentoEtapasPACDentroPrazoDomainService = cumprimentoEtapasPACDentroPrazoDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _cumprimentoEtapasPACDentroPrazoMetaDomainService = cumprimentoEtapasPACDentroPrazoMetaDomainService;
            _cumprimentoEtapasPACDentroPrazoMetaRepository = cumprimentoEtapasPACDentroPrazoMetaRepository;
            _cumprimentoEtapasPACDentroPrazoRepository = cumprimentoEtapasPACDentroPrazoRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<CumprimentoEtapasPACDentroPrazo> cumprimentoEtapasPACDentroPrazoList = new List<CumprimentoEtapasPACDentroPrazo>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var cumprimentoEtapasPACDentroPrazoCount = _cumprimentoEtapasPACDentroPrazoDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoCumprimentoEtapasPACDentroPrazoList = _cumprimentoEtapasPACDentroPrazoDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _cumprimentoEtapasPACDentroPrazoMetaDomainService.GetAllAsync().Result.ToList();
          //  var anolList = _cumprimentoEtapasPACDentroPrazoRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsCumprimentoEtapasPACDentroPrazo)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoCumprimentoEtapasPACDentroPrazoList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            CumprimentoEtapasPACDentroPrazo cumprimentoEtapasPACDentroPrazo = new CumprimentoEtapasPACDentroPrazo
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Mes = (EnumMes)i,
                                Meta = (int)ano.Meta
                            };

                            cumprimentoEtapasPACDentroPrazoList.Add(cumprimentoEtapasPACDentroPrazo);
                        }
                    }
                }
            }

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var logs = new List<LogCrud>();
                var log = new LogCrud()
                {
                    IdReferencia = usuarioLogado.Id,
                    DataHoraCadastro = DateTime.Now,
                    UsuarioId = usuarioLogado.Id,
                    UsuarioNome = usuarioLogado.Nome,
                    LogTipo = LogTipo.Cadastrado,
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_CumprimentoEtapasPACDentroPrazo").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Cumprimento Etapas PAC Dentro Prazo para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };
                
                await _logCrudRepository.AddListAsync(logs);

                await _cumprimentoEtapasPACDentroPrazoDomainService.AddListAsync(cumprimentoEtapasPACDentroPrazoList);

                transaction.Complete();

            }
        }


        public async Task<CumprimentoEtapasPACDentroPrazoResponseDTO> UpdateAsync(long id, CumprimentoEtapasPACDentroPrazoRequestDTO request)
        {
            var model = _mapper.Map<CumprimentoEtapasPACDentroPrazo>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_CumprimentoEtapasPACDentroPrazo");

            // Inicia uma transação
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    foreach (var item in await logs)
                    {
                        item.IdReferencia = model.Id;
                        await _logCrudRepository.AddAsync(item);
                    }

                    var result = await _cumprimentoEtapasPACDentroPrazoDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<CumprimentoEtapasPACDentroPrazoResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }

     

        public async Task<CumprimentoEtapasPACDentroPrazoResponseDTO> DeleteAsync(long id)
        {
            var model = await _cumprimentoEtapasPACDentroPrazoDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_CumprimentoEtapasPACDentroPrazo".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Cumprimento Etapas PAC Dentro Prazo do período {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _cumprimentoEtapasPACDentroPrazoDomainService.DeleteAsync(id);

            return _mapper.Map<CumprimentoEtapasPACDentroPrazoResponseDTO>(result);

        }

        public async Task<CumprimentoEtapasPACDentroPrazoResponseDTO> GetByIdAsync(long id)
        {
            var result = await _cumprimentoEtapasPACDentroPrazoDomainService.GetByIdAsync(id);
            return _mapper.Map<CumprimentoEtapasPACDentroPrazoResponseDTO>(result);
        }


        public async Task<List<CumprimentoEtapasPACDentroPrazoResponseDTO>> GetAllAsync()
        {
            var result = await _cumprimentoEtapasPACDentroPrazoDomainService.GetAllAsync();

            return _mapper.Map<List<CumprimentoEtapasPACDentroPrazoResponseDTO>>(result);
        }

         public async Task<List<CumprimentoEtapasPACDentroPrazoResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _cumprimentoEtapasPACDentroPrazoDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            return _mapper.Map<List<CumprimentoEtapasPACDentroPrazoResponseDTO>>(result);
        }

        public async Task<List<CumprimentoEtapasPACDentroPrazoResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _cumprimentoEtapasPACDentroPrazoDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<CumprimentoEtapasPACDentroPrazoResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(CumprimentoEtapasPACDentroPrazoRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());


            //Log de diferenças
            if (request.Id != 0)
            {
                CumprimentoEtapasPACDentroPrazo requestOld = _mapper.Map<CumprimentoEtapasPACDentroPrazo>(GetByIdAsync(request.Id).Result);
                CumprimentoEtapasPACDentroPrazo requestNew = _mapper.Map<CumprimentoEtapasPACDentroPrazo>(request);

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
            _cumprimentoEtapasPACDentroPrazoDomainService.Dispose();
        }


    }
}
