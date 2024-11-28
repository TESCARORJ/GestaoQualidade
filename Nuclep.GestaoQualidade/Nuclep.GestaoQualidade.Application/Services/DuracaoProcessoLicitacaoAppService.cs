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
    public class DuracaoProcessoLicitacaoAppService : IDuracaoProcessoLicitacaoAppService
    {
        private readonly IDuracaoProcessoLicitacaoDomainService _duracaoProcessoLicitacaoDomainService;
        private readonly IDuracaoProcessoLicitacaoMetaDomainService _duracaoProcessoLicitacaoMetaDomainService;
        private readonly IDuracaoProcessoLicitacaoMetaRepository _duracaoProcessoLicitacaoMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IDuracaoProcessoLicitacaoRepository _duracaoProcessoLicitacaoRepository;



        public DuracaoProcessoLicitacaoAppService(
            IDuracaoProcessoLicitacaoDomainService duracaoProcessoLicitacaoDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IDuracaoProcessoLicitacaoMetaDomainService duracaoProcessoLicitacaoMetaDomainService,
            IDuracaoProcessoLicitacaoMetaRepository duracaoProcessoLicitacaoMetaRepository,
            IDuracaoProcessoLicitacaoRepository duracaoProcessoLicitacaoRepository)
        {
            _duracaoProcessoLicitacaoDomainService = duracaoProcessoLicitacaoDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _duracaoProcessoLicitacaoMetaDomainService = duracaoProcessoLicitacaoMetaDomainService;
            _duracaoProcessoLicitacaoMetaRepository = duracaoProcessoLicitacaoMetaRepository;
            _duracaoProcessoLicitacaoRepository = duracaoProcessoLicitacaoRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<DuracaoProcessoLicitacao> duracaoProcessoLicitacaoList = new List<DuracaoProcessoLicitacao>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var duracaoProcessoLicitacaoCount = _duracaoProcessoLicitacaoDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoDuracaoProcessoLicitacaoList = _duracaoProcessoLicitacaoDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _duracaoProcessoLicitacaoMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _duracaoProcessoLicitacaoRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsDuracaoProcessoLicitacao)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoDuracaoProcessoLicitacaoList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            DuracaoProcessoLicitacao duracaoProcessoLicitacao = new DuracaoProcessoLicitacao
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Trimestre = (EnumTrimestre)i,
                                Meta = (int)ano.Meta
                            };

                            duracaoProcessoLicitacaoList.Add(duracaoProcessoLicitacao);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_DuracaoProcessoLicitacao").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Faturamentos Realizados para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _duracaoProcessoLicitacaoDomainService.AddListAsync(duracaoProcessoLicitacaoList);

                transaction.Complete();

            }
        }


        public async Task<DuracaoProcessoLicitacaoResponseDTO> UpdateAsync(long id, DuracaoProcessoLicitacaoRequestDTO request)
        {
            var model = _mapper.Map<DuracaoProcessoLicitacao>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_DuracaoProcessoLicitacao");

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

                    var result = await _duracaoProcessoLicitacaoDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<DuracaoProcessoLicitacaoResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }



        public async Task<DuracaoProcessoLicitacaoResponseDTO> DeleteAsync(long id)
        {
            var model = await _duracaoProcessoLicitacaoDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_DuracaoProcessoLicitacao".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Faturamento Realizado de valor {model.Trimestre} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _duracaoProcessoLicitacaoDomainService.DeleteAsync(id);

            return _mapper.Map<DuracaoProcessoLicitacaoResponseDTO>(result);

        }

        public async Task<DuracaoProcessoLicitacaoResponseDTO> GetByIdAsync(long id)
        {
            var result = await _duracaoProcessoLicitacaoDomainService.GetByIdAsync(id);
            return _mapper.Map<DuracaoProcessoLicitacaoResponseDTO>(result);
        }


        public async Task<List<DuracaoProcessoLicitacaoResponseDTO>> GetAllAsync()
        {
            var result = await _duracaoProcessoLicitacaoDomainService.GetAllAsync();

            return _mapper.Map<List<DuracaoProcessoLicitacaoResponseDTO>>(result);
        }
        public async Task<List<DuracaoProcessoLicitacaoResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _duracaoProcessoLicitacaoDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            return _mapper.Map<List<DuracaoProcessoLicitacaoResponseDTO>>(result);
        }

        public async Task<List<DuracaoProcessoLicitacaoResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _duracaoProcessoLicitacaoDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<DuracaoProcessoLicitacaoResponseDTO>>(result);
        }

        private List<LogCrud> Logar(DuracaoProcessoLicitacaoRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            //Log de diferenças
            if (request.Id != 0)
            {
                DuracaoProcessoLicitacao requestOld = _mapper.Map<DuracaoProcessoLicitacao>(GetByIdAsync(request.Id).Result);
                DuracaoProcessoLicitacao requestNew = _mapper.Map<DuracaoProcessoLicitacao>(request);

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
                logs.Add(new LogCrud(usuarioLogado.Id, usuarioLogado.Nome, LogTipo.Cadastrado,
                    _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower().Equals(tabela.ToLower())).Result.Id, null,
                    null, null));
            }

            return logs;
        }

        public void Dispose()
        {
            _duracaoProcessoLicitacaoDomainService.Dispose();
        }


    }
}
