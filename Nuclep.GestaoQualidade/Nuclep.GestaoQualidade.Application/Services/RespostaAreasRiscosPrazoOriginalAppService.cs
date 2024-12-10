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
using System.Transactions;

namespace Nuclep.GestaoQualidade.Application.Services
{
    public class RespostaAreasRiscosPrazoOriginalAppService : IRespostaAreasRiscosPrazoOriginalAppService
    {
        private readonly IRespostaAreasRiscosPrazoOriginalDomainService _respostaAreasRiscosPrazoOriginalDomainService;
        private readonly IRespostaAreasRiscosPrazoOriginalMetaDomainService _respostaAreasRiscosPrazoOriginalMetaDomainService;
        private readonly IRespostaAreasRiscosPrazoOriginalMetaRepository _respostaAreasRiscosPrazoOriginalMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IRespostaAreasRiscosPrazoOriginalRepository _respostaAreasRiscosPrazoOriginalRepository;



        public RespostaAreasRiscosPrazoOriginalAppService(
            IRespostaAreasRiscosPrazoOriginalDomainService respostaAreasRiscosPrazoOriginalDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IRespostaAreasRiscosPrazoOriginalMetaDomainService respostaAreasRiscosPrazoOriginalMetaDomainService,
            IRespostaAreasRiscosPrazoOriginalMetaRepository respostaAreasRiscosPrazoOriginalMetaRepository,
            IRespostaAreasRiscosPrazoOriginalRepository respostaAreasRiscosPrazoOriginalRepository)
        {
            _respostaAreasRiscosPrazoOriginalDomainService = respostaAreasRiscosPrazoOriginalDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _respostaAreasRiscosPrazoOriginalMetaDomainService = respostaAreasRiscosPrazoOriginalMetaDomainService;
            _respostaAreasRiscosPrazoOriginalMetaRepository = respostaAreasRiscosPrazoOriginalMetaRepository;
            _respostaAreasRiscosPrazoOriginalRepository = respostaAreasRiscosPrazoOriginalRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<RespostaAreasRiscosPrazoOriginal> respostaAreasRiscosPrazoOriginalList = new List<RespostaAreasRiscosPrazoOriginal>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var respostaAreasRiscosPrazoOriginalCount = _respostaAreasRiscosPrazoOriginalDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoRespostaAreasRiscosPrazoOriginalList = _respostaAreasRiscosPrazoOriginalDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _respostaAreasRiscosPrazoOriginalMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _respostaAreasRiscosPrazoOriginalRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsRespostaAreasRiscosPrazoOriginal)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoRespostaAreasRiscosPrazoOriginalList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            RespostaAreasRiscosPrazoOriginal respostaAreasRiscosPrazoOriginal = new RespostaAreasRiscosPrazoOriginal
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Trimestre = (EnumTrimestre)i,
                                Meta = (int)ano.Meta
                            };

                            respostaAreasRiscosPrazoOriginalList.Add(respostaAreasRiscosPrazoOriginal);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_RespostaAreasRiscosPrazoOriginal").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Resposta de Áreas de Riscos de Prazo Original para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _respostaAreasRiscosPrazoOriginalDomainService.AddListAsync(respostaAreasRiscosPrazoOriginalList);

                transaction.Complete();

            }
        }


        public async Task<RespostaAreasRiscosPrazoOriginalResponseDTO> UpdateAsync(long id, RespostaAreasRiscosPrazoOriginalRequestDTO request)
        {
            var model = _mapper.Map<RespostaAreasRiscosPrazoOriginal>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_RespostaAreasRiscosPrazoOriginal");

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

                    var result = await _respostaAreasRiscosPrazoOriginalDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<RespostaAreasRiscosPrazoOriginalResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }

        public async Task<RespostaAreasRiscosPrazoOriginalResponseDTO> DeleteAsync(long id)
        {
            var model = await _respostaAreasRiscosPrazoOriginalDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_RespostaAreasRiscosPrazoOriginal".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Resposta de Áreas de Riscos de Prazo Original do período {model.Trimestre} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _respostaAreasRiscosPrazoOriginalDomainService.DeleteAsync(id);

            return _mapper.Map<RespostaAreasRiscosPrazoOriginalResponseDTO>(result);

        }

        public async Task<RespostaAreasRiscosPrazoOriginalResponseDTO> GetByIdAsync(long id)
        {
            var result = await _respostaAreasRiscosPrazoOriginalDomainService.GetByIdAsync(id);
            return _mapper.Map<RespostaAreasRiscosPrazoOriginalResponseDTO>(result);
        }

        public async Task<List<RespostaAreasRiscosPrazoOriginalResponseDTO>> GetAllAsync()
        {
            var result = await _respostaAreasRiscosPrazoOriginalDomainService.GetAllAsync();

            return _mapper.Map<List<RespostaAreasRiscosPrazoOriginalResponseDTO>>(result);
        }
        public async Task<List<RespostaAreasRiscosPrazoOriginalResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _respostaAreasRiscosPrazoOriginalDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            return _mapper.Map<List<RespostaAreasRiscosPrazoOriginalResponseDTO>>(result);
        }

        public async Task<List<RespostaAreasRiscosPrazoOriginalResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _respostaAreasRiscosPrazoOriginalDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<RespostaAreasRiscosPrazoOriginalResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(RespostaAreasRiscosPrazoOriginalRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                RespostaAreasRiscosPrazoOriginal requestOld = _mapper.Map<RespostaAreasRiscosPrazoOriginal>(GetByIdAsync(request.Id).Result);
                RespostaAreasRiscosPrazoOriginal requestNew = _mapper.Map<RespostaAreasRiscosPrazoOriginal>(request);

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
            _respostaAreasRiscosPrazoOriginalDomainService.Dispose();
        }


    }
}
