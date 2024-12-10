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
    public class RejeicaoMateriaisAppService : IRejeicaoMateriaisAppService
    {
        private readonly IRejeicaoMateriaisDomainService _rejeicaoMateriaisDomainService;
        private readonly IRejeicaoMateriaisMetaDomainService _rejeicaoMateriaisMetaDomainService;
        private readonly IRejeicaoMateriaisMetaRepository _rejeicaoMateriaisMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IRejeicaoMateriaisRepository _rejeicaoMateriaisRepository;



        public RejeicaoMateriaisAppService(
            IRejeicaoMateriaisDomainService rejeicaoMateriaisDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IRejeicaoMateriaisMetaDomainService rejeicaoMateriaisMetaDomainService,
            IRejeicaoMateriaisMetaRepository rejeicaoMateriaisMetaRepository,
            IRejeicaoMateriaisRepository rejeicaoMateriaisRepository)
        {
            _rejeicaoMateriaisDomainService = rejeicaoMateriaisDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _rejeicaoMateriaisMetaDomainService = rejeicaoMateriaisMetaDomainService;
            _rejeicaoMateriaisMetaRepository = rejeicaoMateriaisMetaRepository;
            _rejeicaoMateriaisRepository = rejeicaoMateriaisRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<RejeicaoMateriais> rejeicaoMateriaisList = new List<RejeicaoMateriais>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var rejeicaoMateriaisCount = _rejeicaoMateriaisDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoRejeicaoMateriaisList = _rejeicaoMateriaisDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _rejeicaoMateriaisMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _rejeicaoMateriaisRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsRejeicaoMateriais)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoRejeicaoMateriaisList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            RejeicaoMateriais rejeicaoMateriais = new RejeicaoMateriais
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Trimestre = (EnumTrimestre)i,
                                Meta = (int)ano.Meta
                            };

                            rejeicaoMateriaisList.Add(rejeicaoMateriais);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_RejeicaoMateriais").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Rejeição de Materiais para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _rejeicaoMateriaisDomainService.AddListAsync(rejeicaoMateriaisList);

                transaction.Complete();

            }
        }


        public async Task<RejeicaoMateriaisResponseDTO> UpdateAsync(long id, RejeicaoMateriaisRequestDTO request)
        {
            var model = _mapper.Map<RejeicaoMateriais>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_RejeicaoMateriais");

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

                    var result = await _rejeicaoMateriaisDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<RejeicaoMateriaisResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }



        public async Task<RejeicaoMateriaisResponseDTO> DeleteAsync(long id)
        {
            var model = await _rejeicaoMateriaisDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_RejeicaoMateriais".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Rejeição de Materiais do período {model.Trimestre} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _rejeicaoMateriaisDomainService.DeleteAsync(id);

            return _mapper.Map<RejeicaoMateriaisResponseDTO>(result);

        }

        public async Task<RejeicaoMateriaisResponseDTO> GetByIdAsync(long id)
        {
            var result = await _rejeicaoMateriaisDomainService.GetByIdAsync(id);
            return _mapper.Map<RejeicaoMateriaisResponseDTO>(result);
        }


        public async Task<List<RejeicaoMateriaisResponseDTO>> GetAllAsync()
        {
            var result = await _rejeicaoMateriaisDomainService.GetAllAsync();

            return _mapper.Map<List<RejeicaoMateriaisResponseDTO>>(result);
        }
        public async Task<List<RejeicaoMateriaisResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _rejeicaoMateriaisDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            return _mapper.Map<List<RejeicaoMateriaisResponseDTO>>(result);
        }

        public async Task<List<RejeicaoMateriaisResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _rejeicaoMateriaisDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<RejeicaoMateriaisResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(RejeicaoMateriaisRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                RejeicaoMateriais requestOld = _mapper.Map<RejeicaoMateriais>(GetByIdAsync(request.Id).Result);
                RejeicaoMateriais requestNew = _mapper.Map<RejeicaoMateriais>(request);

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
            _rejeicaoMateriaisDomainService.Dispose();
        }


    }
}
