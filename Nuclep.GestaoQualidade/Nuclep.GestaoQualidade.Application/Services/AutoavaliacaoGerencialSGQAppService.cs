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
    public class AutoavaliacaoGerencialSGQAppService : IAutoavaliacaoGerencialSGQAppService
    {
        private readonly IAutoavaliacaoGerencialSGQDomainService _autoavaliacaoGerencialSGQDomainService;
        private readonly IAutoavaliacaoGerencialSGQMetaDomainService _autoavaliacaoGerencialSGQMetaDomainService;
        private readonly IAutoavaliacaoGerencialSGQMetaRepository _autoavaliacaoGerencialSGQMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IAutoavaliacaoGerencialSGQRepository _autoavaliacaoGerencialSGQRepository;



        public AutoavaliacaoGerencialSGQAppService(
            IAutoavaliacaoGerencialSGQDomainService autoavaliacaoGerencialSGQDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IAutoavaliacaoGerencialSGQMetaDomainService autoavaliacaoGerencialSGQMetaDomainService,
            IAutoavaliacaoGerencialSGQMetaRepository autoavaliacaoGerencialSGQMetaRepository,
            IAutoavaliacaoGerencialSGQRepository autoavaliacaoGerencialSGQRepository)
        {
            _autoavaliacaoGerencialSGQDomainService = autoavaliacaoGerencialSGQDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _autoavaliacaoGerencialSGQMetaDomainService = autoavaliacaoGerencialSGQMetaDomainService;
            _autoavaliacaoGerencialSGQMetaRepository = autoavaliacaoGerencialSGQMetaRepository;
            _autoavaliacaoGerencialSGQRepository = autoavaliacaoGerencialSGQRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<AutoavaliacaoGerencialSGQ> autoavaliacaoGerencialSGQList = new List<AutoavaliacaoGerencialSGQ>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var autoavaliacaoGerencialSGQCount = _autoavaliacaoGerencialSGQDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id).Result.Any();
            var anoAutoavaliacaoGerencialSGQList = _autoavaliacaoGerencialSGQDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id).Result.ToList();
            var anoMetalList = _autoavaliacaoGerencialSGQMetaDomainService.GetAllAsync().Result.ToList();
            

            if (usuarioLogado.IsAutoavaliacaoGerencialSGQ)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoAutoavaliacaoGerencialSGQList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            AutoavaliacaoGerencialSGQ autoavaliacaoGerencialSGQ = new AutoavaliacaoGerencialSGQ
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Meta = (int)ano.Meta
                            };

                            autoavaliacaoGerencialSGQList.Add(autoavaliacaoGerencialSGQ);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_AutoavaliacaoGerencialSGQ").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Faturamentos Realizados para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _autoavaliacaoGerencialSGQDomainService.AddListAsync(autoavaliacaoGerencialSGQList);

                transaction.Complete();

            }
        }


        public async Task<AutoavaliacaoGerencialSGQResponseDTO> UpdateAsync(long id, AutoavaliacaoGerencialSGQRequestDTO request)
        {
            var model = _mapper.Map<AutoavaliacaoGerencialSGQ>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_AutoavaliacaoGerencialSGQ");

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

                    var result = await _autoavaliacaoGerencialSGQDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<AutoavaliacaoGerencialSGQResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }



        public async Task<AutoavaliacaoGerencialSGQResponseDTO> DeleteAsync(long id)
        {
            var model = await _autoavaliacaoGerencialSGQDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_AutoavaliacaoGerencialSGQ".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Faturamento Realizado de valor {model.Realizado} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _autoavaliacaoGerencialSGQDomainService.DeleteAsync(id);

            return _mapper.Map<AutoavaliacaoGerencialSGQResponseDTO>(result);

        }

        public async Task<AutoavaliacaoGerencialSGQResponseDTO> GetByIdAsync(long id)
        {
            var result = await _autoavaliacaoGerencialSGQDomainService.GetByIdAsync(id);
            return _mapper.Map<AutoavaliacaoGerencialSGQResponseDTO>(result);
        }


        public async Task<List<AutoavaliacaoGerencialSGQResponseDTO>> GetAllAsync()
        {
            var result = await _autoavaliacaoGerencialSGQDomainService.GetAllAsync();

            return _mapper.Map<List<AutoavaliacaoGerencialSGQResponseDTO>>(result);
        }
        public async Task<List<AutoavaliacaoGerencialSGQResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _autoavaliacaoGerencialSGQDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            return _mapper.Map<List<AutoavaliacaoGerencialSGQResponseDTO>>(result);
        }

        public async Task<List<AutoavaliacaoGerencialSGQResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _autoavaliacaoGerencialSGQDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<AutoavaliacaoGerencialSGQResponseDTO>>(result);
        }

        private List<LogCrud> Logar(AutoavaliacaoGerencialSGQRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            //Log de diferenças
            if (request.Id != 0)
            {
                AutoavaliacaoGerencialSGQ requestOld = _mapper.Map<AutoavaliacaoGerencialSGQ>(GetByIdAsync(request.Id).Result);
                AutoavaliacaoGerencialSGQ requestNew = _mapper.Map<AutoavaliacaoGerencialSGQ>(request);

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
            _autoavaliacaoGerencialSGQDomainService.Dispose();
        }


    }
}
