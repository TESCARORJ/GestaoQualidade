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
    public class AcaoCorrecaoAvaliadaEficazAppService : IAcaoCorrecaoAvaliadaEficazAppService
    {
        private readonly IAcaoCorrecaoAvaliadaEficazDomainService _acaoCorrecaoAvaliadaEficazDomainService;
        private readonly IAcaoCorrecaoAvaliadaEficazMetaDomainService _acaoCorrecaoAvaliadaEficazMetaDomainService;
        private readonly IAcaoCorrecaoAvaliadaEficazMetaRepository _acaoCorrecaoAvaliadaEficazMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IAcaoCorrecaoAvaliadaEficazRepository _acaoCorrecaoAvaliadaEficazRepository;



        public AcaoCorrecaoAvaliadaEficazAppService(
            IAcaoCorrecaoAvaliadaEficazDomainService acaoCorrecaoAvaliadaEficazDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IAcaoCorrecaoAvaliadaEficazMetaDomainService acaoCorrecaoAvaliadaEficazMetaDomainService,
            IAcaoCorrecaoAvaliadaEficazMetaRepository acaoCorrecaoAvaliadaEficazMetaRepository,
            IAcaoCorrecaoAvaliadaEficazRepository acaoCorrecaoAvaliadaEficazRepository)
        {
            _acaoCorrecaoAvaliadaEficazDomainService = acaoCorrecaoAvaliadaEficazDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _acaoCorrecaoAvaliadaEficazMetaDomainService = acaoCorrecaoAvaliadaEficazMetaDomainService;
            _acaoCorrecaoAvaliadaEficazMetaRepository = acaoCorrecaoAvaliadaEficazMetaRepository;
            _acaoCorrecaoAvaliadaEficazRepository = acaoCorrecaoAvaliadaEficazRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<AcaoCorrecaoAvaliadaEficaz> acaoCorrecaoAvaliadaEficazList = new List<AcaoCorrecaoAvaliadaEficaz>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var acaoCorrecaoAvaliadaEficazCount = _acaoCorrecaoAvaliadaEficazDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoAcaoCorrecaoAvaliadaEficazList = _acaoCorrecaoAvaliadaEficazDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _acaoCorrecaoAvaliadaEficazMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _acaoCorrecaoAvaliadaEficazRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsAcaoCorrecaoAvaliadaEficaz)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoAcaoCorrecaoAvaliadaEficazList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            AcaoCorrecaoAvaliadaEficaz acaoCorrecaoAvaliadaEficaz = new AcaoCorrecaoAvaliadaEficaz
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Trimestre = (EnumTrimestre)i,
                                Meta = (int)ano.Meta
                            };

                            acaoCorrecaoAvaliadaEficazList.Add(acaoCorrecaoAvaliadaEficaz);
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
                    Usuario = usuarioLogado,
                    LogTipo = LogTipo.Cadastrado,
                    LogTabela = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_AcaoCorrecaoAvaliadaEficaz").Result,
                    Descricao = $"Cadastrado períodos de preenchimento de Ação de Correção Avaliada Eficaz para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _acaoCorrecaoAvaliadaEficazDomainService.AddListAsync(acaoCorrecaoAvaliadaEficazList);

                transaction.Complete();

            }
        }


        public async Task<AcaoCorrecaoAvaliadaEficazResponseDTO> UpdateAsync(long id, AcaoCorrecaoAvaliadaEficazRequestDTO request)
        {
            var model = _mapper.Map<AcaoCorrecaoAvaliadaEficaz>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_AcaoCorrecaoAvaliadaEficaz");

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

                    var result = await _acaoCorrecaoAvaliadaEficazDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<AcaoCorrecaoAvaliadaEficazResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }



        public async Task<AcaoCorrecaoAvaliadaEficazResponseDTO> DeleteAsync(long id)
        {
            var model = await _acaoCorrecaoAvaliadaEficazDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                Usuario = usuarioLogado,
                LogTipo = LogTipo.Cadastrado,
                LogTabela = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_AcaoCorrecaoAvaliadaEficaz".ToLower()).Result,
                IdReferencia = model.Id,
                Descricao = $" Ação de Correção Avaliada Eficaz de valor {model.Trimestre} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _acaoCorrecaoAvaliadaEficazDomainService.DeleteAsync(id);

            return _mapper.Map<AcaoCorrecaoAvaliadaEficazResponseDTO>(result);

        }

        public async Task<AcaoCorrecaoAvaliadaEficazResponseDTO> GetByIdAsync(long id)
        {
            var result = await _acaoCorrecaoAvaliadaEficazDomainService.GetByIdAsync(id);
            return _mapper.Map<AcaoCorrecaoAvaliadaEficazResponseDTO>(result);
        }


        public async Task<List<AcaoCorrecaoAvaliadaEficazResponseDTO>> GetAllAsync()
        {
            var result = await _acaoCorrecaoAvaliadaEficazDomainService.GetAllAsync();

            return _mapper.Map<List<AcaoCorrecaoAvaliadaEficazResponseDTO>>(result);
        }
        public async Task<List<AcaoCorrecaoAvaliadaEficazResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _acaoCorrecaoAvaliadaEficazDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            return _mapper.Map<List<AcaoCorrecaoAvaliadaEficazResponseDTO>>(result);
        }
        public async Task<List<AcaoCorrecaoAvaliadaEficazResponseDTO>> GetAllAtivosAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _acaoCorrecaoAvaliadaEficazDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<AcaoCorrecaoAvaliadaEficazResponseDTO>>(result);
        }

        private List<LogCrud> Logar(AcaoCorrecaoAvaliadaEficazRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            //Log de diferenças
            if (request.Id != 0)
            {
                AcaoCorrecaoAvaliadaEficaz requestOld = _mapper.Map<AcaoCorrecaoAvaliadaEficaz>(GetByIdAsync(request.Id).Result);
                AcaoCorrecaoAvaliadaEficaz requestNew = _mapper.Map<AcaoCorrecaoAvaliadaEficaz>(request);

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
                logs.Add(new LogCrud(usuarioLogado, LogTipo.Cadastrado,
                    _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower().Equals(tabela.ToLower())).Result, null,
                    null, null));
            }

            return logs;
        }

        public void Dispose()
        {
            _acaoCorrecaoAvaliadaEficazDomainService.Dispose();
        }


    }
}
