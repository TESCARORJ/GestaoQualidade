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
    public class FaturamentoRealizadoAppService : IFaturamentoRealizadoAppService
    {
        private readonly IFaturamentoRealizadoDomainService _faturamentoRealizadoDomainService;
        private readonly IFaturamentoRealizadoMetaDomainService _faturamentoRealizadoMetaDomainService;
        private readonly IFaturamentoRealizadoMetaRepository _faturamentoRealizadoMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IFaturamentoRealizadoRepository _faturamentoRealizadoRepository;



        public FaturamentoRealizadoAppService(
            IFaturamentoRealizadoDomainService faturamentoRealizadoDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IFaturamentoRealizadoMetaDomainService faturamentoRealizadoMetaDomainService,
            IFaturamentoRealizadoMetaRepository faturamentoRealizadoMetaRepository,
            IFaturamentoRealizadoRepository faturamentoRealizadoRepository)
        {
            _faturamentoRealizadoDomainService = faturamentoRealizadoDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _faturamentoRealizadoMetaDomainService = faturamentoRealizadoMetaDomainService;
            _faturamentoRealizadoMetaRepository = faturamentoRealizadoMetaRepository;
            _faturamentoRealizadoRepository = faturamentoRealizadoRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<FaturamentoRealizado> faturamentoRealizadoList = new List<FaturamentoRealizado>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var faturamentoRealizadoCount = _faturamentoRealizadoDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoFaturamentoRealizadoList = _faturamentoRealizadoDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _faturamentoRealizadoMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _faturamentoRealizadoRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsFaturamentoRealizado)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoFaturamentoRealizadoList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            FaturamentoRealizado faturamentoRealizado = new FaturamentoRealizado
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Trimestre = (EnumTrimestre)i,
                                Meta = (int)ano.Meta
                            };

                            faturamentoRealizadoList.Add(faturamentoRealizado);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_FaturamentoRealizado").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Faturamentos Realizados para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _faturamentoRealizadoDomainService.AddListAsync(faturamentoRealizadoList);

                transaction.Complete();

            }
        }


        public async Task<FaturamentoRealizadoResponseDTO> UpdateAsync(long id, FaturamentoRealizadoRequestDTO request)
        {
            var model = _mapper.Map<FaturamentoRealizado>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_FaturamentoRealizado");

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

                    var result = await _faturamentoRealizadoDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<FaturamentoRealizadoResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }



        public async Task<FaturamentoRealizadoResponseDTO> DeleteAsync(long id)
        {
            var model = await _faturamentoRealizadoDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_FaturamentoRealizado".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Faturamento Realizado do período {model.Trimestre} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _faturamentoRealizadoDomainService.DeleteAsync(id);

            return _mapper.Map<FaturamentoRealizadoResponseDTO>(result);

        }

        public async Task<FaturamentoRealizadoResponseDTO> GetByIdAsync(long id)
        {
            var result = await _faturamentoRealizadoDomainService.GetByIdAsync(id);
            return _mapper.Map<FaturamentoRealizadoResponseDTO>(result);
        }


        public async Task<List<FaturamentoRealizadoResponseDTO>> GetAllAsync()
        {
            var result = await _faturamentoRealizadoDomainService.GetAllAsync();

            return _mapper.Map<List<FaturamentoRealizadoResponseDTO>>(result);
        }
        public async Task<List<FaturamentoRealizadoResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _faturamentoRealizadoDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            return _mapper.Map<List<FaturamentoRealizadoResponseDTO>>(result);
        }

        public async Task<List<FaturamentoRealizadoResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _faturamentoRealizadoDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<FaturamentoRealizadoResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(FaturamentoRealizadoRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());


            //Log de diferenças
            if (request.Id != 0)
            {
                FaturamentoRealizado requestOld = _mapper.Map<FaturamentoRealizado>(GetByIdAsync(request.Id).Result);
                FaturamentoRealizado requestNew = _mapper.Map<FaturamentoRealizado>(request);

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
            _faturamentoRealizadoDomainService.Dispose();
        }


    }
}
