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
    public class ServiceLevelAgreementAppService : IServiceLevelAgreementAppService
    {
        private readonly IServiceLevelAgreementDomainService _serviceLevelAgreementDomainService;
        private readonly IServiceLevelAgreementMetaDomainService _serviceLevelAgreementMetaDomainService;
        private readonly IServiceLevelAgreementMetaRepository _serviceLevelAgreementMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IServiceLevelAgreementRepository _serviceLevelAgreementRepository;
        private readonly ILocalidadeRepository _localidadeRepository;



        public ServiceLevelAgreementAppService(
            IServiceLevelAgreementDomainService serviceLevelAgreementDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IServiceLevelAgreementMetaDomainService serviceLevelAgreementMetaDomainService,
            IServiceLevelAgreementMetaRepository serviceLevelAgreementMetaRepository,
            IServiceLevelAgreementRepository serviceLevelAgreementRepository,
            ILocalidadeRepository localidadeRepository)
        {
            _serviceLevelAgreementDomainService = serviceLevelAgreementDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _serviceLevelAgreementMetaDomainService = serviceLevelAgreementMetaDomainService;
            _serviceLevelAgreementMetaRepository = serviceLevelAgreementMetaRepository;
            _serviceLevelAgreementRepository = serviceLevelAgreementRepository;
            _localidadeRepository = localidadeRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<ServiceLevelAgreement> serviceLevelAgreementList = new List<ServiceLevelAgreement>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var serviceLevelAgreementCount = _serviceLevelAgreementDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoServiceLevelAgreementList = _serviceLevelAgreementDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _serviceLevelAgreementMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _serviceLevelAgreementRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsServiceLevelAgreement)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoServiceLevelAgreementList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            ServiceLevelAgreement serviceLevelAgreement = new ServiceLevelAgreement
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Mes = (EnumMes)i,
                                Meta = (int)ano.Meta
                            };

                            serviceLevelAgreementList.Add(serviceLevelAgreement);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_ServiceLevelAgreement").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Satisfação de Usuario para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _serviceLevelAgreementDomainService.AddListAsync(serviceLevelAgreementList);

                transaction.Complete();

            }
        }

        public async Task<ServiceLevelAgreementResponseDTO> UpdateAsync(long id, ServiceLevelAgreementRequestDTO request)
        {
            var model = _mapper.Map<ServiceLevelAgreement>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_ServiceLevelAgreement");

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

                    var result = await _serviceLevelAgreementDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<ServiceLevelAgreementResponseDTO>(result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }



        }



        public async Task<ServiceLevelAgreementResponseDTO> DeleteAsync(long id)
        {
            var model = await _serviceLevelAgreementDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_ServiceLevelAgreement".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Satisfação de Usuario do período {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _serviceLevelAgreementDomainService.DeleteAsync(id);

            return _mapper.Map<ServiceLevelAgreementResponseDTO>(result);

        }

        public async Task<ServiceLevelAgreementResponseDTO> GetByIdAsync(long id)
        {
            var result = await _serviceLevelAgreementDomainService.GetByIdAsync(id);
            return _mapper.Map<ServiceLevelAgreementResponseDTO>(result);
        }


        public async Task<List<ServiceLevelAgreementResponseDTO>> GetAllAsync()
        {
            var result = await _serviceLevelAgreementDomainService.GetAllAsync();

            return _mapper.Map<List<ServiceLevelAgreementResponseDTO>>(result);
        }
        public async Task<List<ServiceLevelAgreementResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _serviceLevelAgreementDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            var lista = _mapper.Map<List<ServiceLevelAgreementResponseDTO>>(result);

            return lista ;
        }

        public async Task<List<ServiceLevelAgreementResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _serviceLevelAgreementDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<ServiceLevelAgreementResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(ServiceLevelAgreementRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                ServiceLevelAgreement requestOld = _mapper.Map<ServiceLevelAgreement>(GetByIdAsync(request.Id).Result);
                ServiceLevelAgreement requestNew = _mapper.Map<ServiceLevelAgreement>(request);

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
            _serviceLevelAgreementDomainService.Dispose();
        }


    }
}
