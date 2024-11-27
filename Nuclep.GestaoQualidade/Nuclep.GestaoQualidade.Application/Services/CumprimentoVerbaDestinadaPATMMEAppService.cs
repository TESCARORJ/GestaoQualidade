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
    public class CumprimentoVerbaDestinadaPATMMEAppService : ICumprimentoVerbaDestinadaPATMMEAppService
    {
        private readonly ICumprimentoVerbaDestinadaPATMMEDomainService _cumprimentoVerbaDestinadaPATMMEDomainService;
        private readonly ICumprimentoVerbaDestinadaPATMMEMetaDomainService _cumprimentoVerbaDestinadaPATMMEMetaDomainService;
        private readonly ICumprimentoVerbaDestinadaPATMMEMetaRepository _cumprimentoVerbaDestinadaPATMMEMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly ICumprimentoVerbaDestinadaPATMMERepository _cumprimentoVerbaDestinadaPATMMERepository;



        public CumprimentoVerbaDestinadaPATMMEAppService(
            ICumprimentoVerbaDestinadaPATMMEDomainService cumprimentoVerbaDestinadaPATMMEDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            ICumprimentoVerbaDestinadaPATMMEMetaDomainService cumprimentoVerbaDestinadaPATMMEMetaDomainService,
            ICumprimentoVerbaDestinadaPATMMEMetaRepository cumprimentoVerbaDestinadaPATMMEMetaRepository,
            ICumprimentoVerbaDestinadaPATMMERepository cumprimentoVerbaDestinadaPATMMERepository)
        {
            _cumprimentoVerbaDestinadaPATMMEDomainService = cumprimentoVerbaDestinadaPATMMEDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _cumprimentoVerbaDestinadaPATMMEMetaDomainService = cumprimentoVerbaDestinadaPATMMEMetaDomainService;
            _cumprimentoVerbaDestinadaPATMMEMetaRepository = cumprimentoVerbaDestinadaPATMMEMetaRepository;
            _cumprimentoVerbaDestinadaPATMMERepository = cumprimentoVerbaDestinadaPATMMERepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<CumprimentoVerbaDestinadaPATMME> cumprimentoVerbaDestinadaPATMMEList = new List<CumprimentoVerbaDestinadaPATMME>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var cumprimentoVerbaDestinadaPATMMECount = _cumprimentoVerbaDestinadaPATMMEDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoCumprimentoVerbaDestinadaPATMMEList = _cumprimentoVerbaDestinadaPATMMEDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _cumprimentoVerbaDestinadaPATMMEMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _cumprimentoVerbaDestinadaPATMMERepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsCumprimentoVerbaDestinadaPATMME)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoCumprimentoVerbaDestinadaPATMMEList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 2; i++)
                        {
                            CumprimentoVerbaDestinadaPATMME cumprimentoVerbaDestinadaPATMME = new CumprimentoVerbaDestinadaPATMME
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Semestre = (EnumSemestre)i,
                                Meta = (int)ano.Meta
                            };

                            cumprimentoVerbaDestinadaPATMMEList.Add(cumprimentoVerbaDestinadaPATMME);
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
                    LogTabela = _logTabelaRepository.GetOneAsync(x => x.Nome == "CumprimentoVerbaDestinadaPATMME").Result,
                    Descricao = $"Cadastrado períodos de preenchimento de Ação de Correção Avaliada Eficaz para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _cumprimentoVerbaDestinadaPATMMEDomainService.AddListAsync(cumprimentoVerbaDestinadaPATMMEList);

                transaction.Complete();

            }
        }


        public async Task<CumprimentoVerbaDestinadaPATMMEResponseDTO> UpdateAsync(long id, CumprimentoVerbaDestinadaPATMMERequestDTO request)
        {
            var model = _mapper.Map<CumprimentoVerbaDestinadaPATMME>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_CumprimentoVerbaDestinadaPATMME");

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

                    var result = await _cumprimentoVerbaDestinadaPATMMEDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<CumprimentoVerbaDestinadaPATMMEResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }



        public async Task<CumprimentoVerbaDestinadaPATMMEResponseDTO> DeleteAsync(long id)
        {
            var model = await _cumprimentoVerbaDestinadaPATMMEDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                Usuario = usuarioLogado,
                LogTipo = LogTipo.Cadastrado,
                LogTabela = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_CumprimentoVerbaDestinadaPATMME".ToLower()).Result,
                IdReferencia = model.Id,
                Descricao = $" Ação de Correção Avaliada Eficaz de valor {model.Semestre} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _cumprimentoVerbaDestinadaPATMMEDomainService.DeleteAsync(id);

            return _mapper.Map<CumprimentoVerbaDestinadaPATMMEResponseDTO>(result);

        }

        public async Task<CumprimentoVerbaDestinadaPATMMEResponseDTO> GetByIdAsync(long id)
        {
            var result = await _cumprimentoVerbaDestinadaPATMMEDomainService.GetByIdAsync(id);
            return _mapper.Map<CumprimentoVerbaDestinadaPATMMEResponseDTO>(result);
        }


        public async Task<List<CumprimentoVerbaDestinadaPATMMEResponseDTO>> GetAllAsync()
        {
            var result = await _cumprimentoVerbaDestinadaPATMMEDomainService.GetAllAsync();

            return _mapper.Map<List<CumprimentoVerbaDestinadaPATMMEResponseDTO>>(result);
        }
        public async Task<List<CumprimentoVerbaDestinadaPATMMEResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _cumprimentoVerbaDestinadaPATMMEDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            return _mapper.Map<List<CumprimentoVerbaDestinadaPATMMEResponseDTO>>(result);
        }

        public async Task<List<CumprimentoVerbaDestinadaPATMMEResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _cumprimentoVerbaDestinadaPATMMEDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<CumprimentoVerbaDestinadaPATMMEResponseDTO>>(result);
        }

        private List<LogCrud> Logar(CumprimentoVerbaDestinadaPATMMERequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            //Log de diferenças
            if (request.Id != 0)
            {
                CumprimentoVerbaDestinadaPATMME requestOld = _mapper.Map<CumprimentoVerbaDestinadaPATMME>(GetByIdAsync(request.Id).Result);
                CumprimentoVerbaDestinadaPATMME requestNew = _mapper.Map<CumprimentoVerbaDestinadaPATMME>(request);

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
            _cumprimentoVerbaDestinadaPATMMEDomainService.Dispose();
        }


    }
}
