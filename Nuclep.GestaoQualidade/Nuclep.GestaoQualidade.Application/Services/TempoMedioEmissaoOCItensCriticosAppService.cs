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
    public class TempoMedioEmissaoOCItensCriticosAppService : ITempoMedioEmissaoOCItensCriticosAppService
    {
        private readonly ITempoMedioEmissaoOCItensCriticosDomainService _tempoMedioEmissaoOCItensCriticosDomainService;
        private readonly ITempoMedioEmissaoOCItensCriticosMetaDomainService _tempoMedioEmissaoOCItensCriticosMetaDomainService;
        private readonly ITempoMedioEmissaoOCItensCriticosMetaRepository _tempoMedioEmissaoOCItensCriticosMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly ITempoMedioEmissaoOCItensCriticosRepository _tempoMedioEmissaoOCItensCriticosRepository;
        private readonly ILocalidadeRepository _localidadeRepository;



        public TempoMedioEmissaoOCItensCriticosAppService(
            ITempoMedioEmissaoOCItensCriticosDomainService tempoMedioEmissaoOCItensCriticosDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            ITempoMedioEmissaoOCItensCriticosMetaDomainService tempoMedioEmissaoOCItensCriticosMetaDomainService,
            ITempoMedioEmissaoOCItensCriticosMetaRepository tempoMedioEmissaoOCItensCriticosMetaRepository,
            ITempoMedioEmissaoOCItensCriticosRepository tempoMedioEmissaoOCItensCriticosRepository,
            ILocalidadeRepository localidadeRepository)
        {
            _tempoMedioEmissaoOCItensCriticosDomainService = tempoMedioEmissaoOCItensCriticosDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _tempoMedioEmissaoOCItensCriticosMetaDomainService = tempoMedioEmissaoOCItensCriticosMetaDomainService;
            _tempoMedioEmissaoOCItensCriticosMetaRepository = tempoMedioEmissaoOCItensCriticosMetaRepository;
            _tempoMedioEmissaoOCItensCriticosRepository = tempoMedioEmissaoOCItensCriticosRepository;
            _localidadeRepository = localidadeRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<TempoMedioEmissaoOCItensCriticos> tempoMedioEmissaoOCItensCriticosList = new List<TempoMedioEmissaoOCItensCriticos>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var tempoMedioEmissaoOCItensCriticosCount = _tempoMedioEmissaoOCItensCriticosDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoTempoMedioEmissaoOCItensCriticosList = _tempoMedioEmissaoOCItensCriticosDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _tempoMedioEmissaoOCItensCriticosMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _tempoMedioEmissaoOCItensCriticosRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsTempoMedioEmissaoOCItensCriticos)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoTempoMedioEmissaoOCItensCriticosList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            TempoMedioEmissaoOCItensCriticos tempoMedioEmissaoOCItensCriticos = new TempoMedioEmissaoOCItensCriticos
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Mes = (EnumMes)i,
                                Meta = (int)ano.Meta
                            };

                            tempoMedioEmissaoOCItensCriticosList.Add(tempoMedioEmissaoOCItensCriticos);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_TempoMedioEmissaoOCItensCriticos").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Tempo Médio de Emissão OC de Itens Criticos para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _tempoMedioEmissaoOCItensCriticosDomainService.AddListAsync(tempoMedioEmissaoOCItensCriticosList);

                transaction.Complete();

            }
        }

        public async Task<TempoMedioEmissaoOCItensCriticosResponseDTO> UpdateAsync(long id, TempoMedioEmissaoOCItensCriticosRequestDTO request)
        {
            var model = _mapper.Map<TempoMedioEmissaoOCItensCriticos>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_TempoMedioEmissaoOCItensCriticos");

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

                    var result = await _tempoMedioEmissaoOCItensCriticosDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<TempoMedioEmissaoOCItensCriticosResponseDTO>(result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }



        }



        public async Task<TempoMedioEmissaoOCItensCriticosResponseDTO> DeleteAsync(long id)
        {
            var model = await _tempoMedioEmissaoOCItensCriticosDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_TempoMedioEmissaoOCItensCriticos".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Tempo Médio de Emissão OC de Itens Criticos do período {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _tempoMedioEmissaoOCItensCriticosDomainService.DeleteAsync(id);

            return _mapper.Map<TempoMedioEmissaoOCItensCriticosResponseDTO>(result);

        }

        public async Task<TempoMedioEmissaoOCItensCriticosResponseDTO> GetByIdAsync(long id)
        {
            var result = await _tempoMedioEmissaoOCItensCriticosDomainService.GetByIdAsync(id);
            return _mapper.Map<TempoMedioEmissaoOCItensCriticosResponseDTO>(result);
        }


        public async Task<List<TempoMedioEmissaoOCItensCriticosResponseDTO>> GetAllAsync()
        {
            var result = await _tempoMedioEmissaoOCItensCriticosDomainService.GetAllAsync();

            return _mapper.Map<List<TempoMedioEmissaoOCItensCriticosResponseDTO>>(result);
        }
        public async Task<List<TempoMedioEmissaoOCItensCriticosResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _tempoMedioEmissaoOCItensCriticosDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            var lista = _mapper.Map<List<TempoMedioEmissaoOCItensCriticosResponseDTO>>(result);

            return lista ;
        }

        public async Task<List<TempoMedioEmissaoOCItensCriticosResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _tempoMedioEmissaoOCItensCriticosDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<TempoMedioEmissaoOCItensCriticosResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(TempoMedioEmissaoOCItensCriticosRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                TempoMedioEmissaoOCItensCriticos requestOld = _mapper.Map<TempoMedioEmissaoOCItensCriticos>(GetByIdAsync(request.Id).Result);
                TempoMedioEmissaoOCItensCriticos requestNew = _mapper.Map<TempoMedioEmissaoOCItensCriticos>(request);

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
            _tempoMedioEmissaoOCItensCriticosDomainService.Dispose();
        }


    }
}
