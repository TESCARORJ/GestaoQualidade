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
    public class TempoMedioSolucaoAppService : ITempoMedioSolucaoAppService
    {
        private readonly ITempoMedioSolucaoDomainService _tempoMedioSolucaoDomainService;
        private readonly ITempoMedioSolucaoMetaDomainService _tempoMedioSolucaoMetaDomainService;
        private readonly ITempoMedioSolucaoMetaRepository _tempoMedioSolucaoMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly ITempoMedioSolucaoRepository _tempoMedioSolucaoRepository;
        private readonly ILocalidadeRepository _localidadeRepository;



        public TempoMedioSolucaoAppService(
            ITempoMedioSolucaoDomainService tempoMedioSolucaoDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            ITempoMedioSolucaoMetaDomainService tempoMedioSolucaoMetaDomainService,
            ITempoMedioSolucaoMetaRepository tempoMedioSolucaoMetaRepository,
            ITempoMedioSolucaoRepository tempoMedioSolucaoRepository,
            ILocalidadeRepository localidadeRepository)
        {
            _tempoMedioSolucaoDomainService = tempoMedioSolucaoDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _tempoMedioSolucaoMetaDomainService = tempoMedioSolucaoMetaDomainService;
            _tempoMedioSolucaoMetaRepository = tempoMedioSolucaoMetaRepository;
            _tempoMedioSolucaoRepository = tempoMedioSolucaoRepository;
            _localidadeRepository = localidadeRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<TempoMedioSolucao> tempoMedioSolucaoList = new List<TempoMedioSolucao>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var tempoMedioSolucaoCount = _tempoMedioSolucaoDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoTempoMedioSolucaoList = _tempoMedioSolucaoDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _tempoMedioSolucaoMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _tempoMedioSolucaoRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsTempoMedioSolucao)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoTempoMedioSolucaoList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            TempoMedioSolucao tempoMedioSolucao = new TempoMedioSolucao
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Mes = (EnumMes)i,
                                Meta = (int)ano.Meta
                            };

                            tempoMedioSolucaoList.Add(tempoMedioSolucao);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_TempoMedioSolucao").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Satisfação de Usuario para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _tempoMedioSolucaoDomainService.AddListAsync(tempoMedioSolucaoList);

                transaction.Complete();

            }
        }

        public async Task<TempoMedioSolucaoResponseDTO> UpdateAsync(long id, TempoMedioSolucaoRequestDTO request)
        {
            var model = _mapper.Map<TempoMedioSolucao>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_TempoMedioSolucao");

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

                    var result = await _tempoMedioSolucaoDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<TempoMedioSolucaoResponseDTO>(result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }



        }



        public async Task<TempoMedioSolucaoResponseDTO> DeleteAsync(long id)
        {
            var model = await _tempoMedioSolucaoDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_TempoMedioSolucao".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Satisfação de Usuario do período {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _tempoMedioSolucaoDomainService.DeleteAsync(id);

            return _mapper.Map<TempoMedioSolucaoResponseDTO>(result);

        }

        public async Task<TempoMedioSolucaoResponseDTO> GetByIdAsync(long id)
        {
            var result = await _tempoMedioSolucaoDomainService.GetByIdAsync(id);
            return _mapper.Map<TempoMedioSolucaoResponseDTO>(result);
        }


        public async Task<List<TempoMedioSolucaoResponseDTO>> GetAllAsync()
        {
            var result = await _tempoMedioSolucaoDomainService.GetAllAsync();

            return _mapper.Map<List<TempoMedioSolucaoResponseDTO>>(result);
        }
        public async Task<List<TempoMedioSolucaoResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _tempoMedioSolucaoDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            var lista = _mapper.Map<List<TempoMedioSolucaoResponseDTO>>(result);

            return lista ;
        }

        public async Task<List<TempoMedioSolucaoResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _tempoMedioSolucaoDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<TempoMedioSolucaoResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(TempoMedioSolucaoRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                TempoMedioSolucao requestOld = _mapper.Map<TempoMedioSolucao>(GetByIdAsync(request.Id).Result);
                TempoMedioSolucao requestNew = _mapper.Map<TempoMedioSolucao>(request);

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
            _tempoMedioSolucaoDomainService.Dispose();
        }


    }
}
