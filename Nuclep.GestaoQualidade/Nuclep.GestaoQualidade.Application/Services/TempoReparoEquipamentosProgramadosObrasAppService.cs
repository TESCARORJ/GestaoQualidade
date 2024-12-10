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
    public class TempoReparoEquipamentosProgramadosObrasAppService : ITempoReparoEquipamentosProgramadosObrasAppService
    {
        private readonly ITempoReparoEquipamentosProgramadosObrasDomainService _tempoReparoEquipamentosProgramadosObrasDomainService;
        private readonly ITempoReparoEquipamentosProgramadosObrasMetaDomainService _tempoReparoEquipamentosProgramadosObrasMetaDomainService;
        private readonly ITempoReparoEquipamentosProgramadosObrasMetaRepository _tempoReparoEquipamentosProgramadosObrasMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly ITempoReparoEquipamentosProgramadosObrasRepository _tempoReparoEquipamentosProgramadosObrasRepository;
        private readonly ILocalidadeRepository _localidadeRepository;



        public TempoReparoEquipamentosProgramadosObrasAppService(
            ITempoReparoEquipamentosProgramadosObrasDomainService tempoReparoEquipamentosProgramadosObrasDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            ITempoReparoEquipamentosProgramadosObrasMetaDomainService tempoReparoEquipamentosProgramadosObrasMetaDomainService,
            ITempoReparoEquipamentosProgramadosObrasMetaRepository tempoReparoEquipamentosProgramadosObrasMetaRepository,
            ITempoReparoEquipamentosProgramadosObrasRepository tempoReparoEquipamentosProgramadosObrasRepository,
            ILocalidadeRepository localidadeRepository)
        {
            _tempoReparoEquipamentosProgramadosObrasDomainService = tempoReparoEquipamentosProgramadosObrasDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _tempoReparoEquipamentosProgramadosObrasMetaDomainService = tempoReparoEquipamentosProgramadosObrasMetaDomainService;
            _tempoReparoEquipamentosProgramadosObrasMetaRepository = tempoReparoEquipamentosProgramadosObrasMetaRepository;
            _tempoReparoEquipamentosProgramadosObrasRepository = tempoReparoEquipamentosProgramadosObrasRepository;
            _localidadeRepository = localidadeRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<TempoReparoEquipamentosProgramadosObras> tempoReparoEquipamentosProgramadosObrasList = new List<TempoReparoEquipamentosProgramadosObras>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var tempoReparoEquipamentosProgramadosObrasCount = _tempoReparoEquipamentosProgramadosObrasDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoTempoReparoEquipamentosProgramadosObrasList = _tempoReparoEquipamentosProgramadosObrasDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _tempoReparoEquipamentosProgramadosObrasMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _tempoReparoEquipamentosProgramadosObrasRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsTempoReparoEquipamentosProgramadosObras)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoTempoReparoEquipamentosProgramadosObrasList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            TempoReparoEquipamentosProgramadosObras tempoReparoEquipamentosProgramadosObras = new TempoReparoEquipamentosProgramadosObras
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Mes = (EnumMes)i,
                                Meta = (int)ano.Meta
                            };

                            tempoReparoEquipamentosProgramadosObrasList.Add(tempoReparoEquipamentosProgramadosObras);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_TempoReparoEquipamentosProgramadosObras").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Satisfação de Usuario para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _tempoReparoEquipamentosProgramadosObrasDomainService.AddListAsync(tempoReparoEquipamentosProgramadosObrasList);

                transaction.Complete();

            }
        }

        public async Task<TempoReparoEquipamentosProgramadosObrasResponseDTO> UpdateAsync(long id, TempoReparoEquipamentosProgramadosObrasRequestDTO request)
        {
            var model = _mapper.Map<TempoReparoEquipamentosProgramadosObras>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_TempoReparoEquipamentosProgramadosObras");

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

                    var result = await _tempoReparoEquipamentosProgramadosObrasDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<TempoReparoEquipamentosProgramadosObrasResponseDTO>(result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }



        }



        public async Task<TempoReparoEquipamentosProgramadosObrasResponseDTO> DeleteAsync(long id)
        {
            var model = await _tempoReparoEquipamentosProgramadosObrasDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_TempoReparoEquipamentosProgramadosObras".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Satisfação de Usuario do período {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _tempoReparoEquipamentosProgramadosObrasDomainService.DeleteAsync(id);

            return _mapper.Map<TempoReparoEquipamentosProgramadosObrasResponseDTO>(result);

        }

        public async Task<TempoReparoEquipamentosProgramadosObrasResponseDTO> GetByIdAsync(long id)
        {
            var result = await _tempoReparoEquipamentosProgramadosObrasDomainService.GetByIdAsync(id);
            return _mapper.Map<TempoReparoEquipamentosProgramadosObrasResponseDTO>(result);
        }


        public async Task<List<TempoReparoEquipamentosProgramadosObrasResponseDTO>> GetAllAsync()
        {
            var result = await _tempoReparoEquipamentosProgramadosObrasDomainService.GetAllAsync();

            return _mapper.Map<List<TempoReparoEquipamentosProgramadosObrasResponseDTO>>(result);
        }
        public async Task<List<TempoReparoEquipamentosProgramadosObrasResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _tempoReparoEquipamentosProgramadosObrasDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            var lista = _mapper.Map<List<TempoReparoEquipamentosProgramadosObrasResponseDTO>>(result);

            return lista ;
        }

        public async Task<List<TempoReparoEquipamentosProgramadosObrasResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _tempoReparoEquipamentosProgramadosObrasDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<TempoReparoEquipamentosProgramadosObrasResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(TempoReparoEquipamentosProgramadosObrasRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                TempoReparoEquipamentosProgramadosObras requestOld = _mapper.Map<TempoReparoEquipamentosProgramadosObras>(GetByIdAsync(request.Id).Result);
                TempoReparoEquipamentosProgramadosObras requestNew = _mapper.Map<TempoReparoEquipamentosProgramadosObras>(request);

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
            _tempoReparoEquipamentosProgramadosObrasDomainService.Dispose();
        }


    }
}
