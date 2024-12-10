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
    public class TaxaConformidadeDocumentosQualidadeAppService : ITaxaConformidadeDocumentosQualidadeAppService
    {
        private readonly ITaxaConformidadeDocumentosQualidadeDomainService _autoavaliacaoGerencialSGQDomainService;
        private readonly ITaxaConformidadeDocumentosQualidadeMetaDomainService _autoavaliacaoGerencialSGQMetaDomainService;
        private readonly ITaxaConformidadeDocumentosQualidadeMetaRepository _autoavaliacaoGerencialSGQMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly ITaxaConformidadeDocumentosQualidadeRepository _autoavaliacaoGerencialSGQRepository;



        public TaxaConformidadeDocumentosQualidadeAppService(
            ITaxaConformidadeDocumentosQualidadeDomainService autoavaliacaoGerencialSGQDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            ITaxaConformidadeDocumentosQualidadeMetaDomainService autoavaliacaoGerencialSGQMetaDomainService,
            ITaxaConformidadeDocumentosQualidadeMetaRepository autoavaliacaoGerencialSGQMetaRepository,
            ITaxaConformidadeDocumentosQualidadeRepository autoavaliacaoGerencialSGQRepository)
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
            List<TaxaConformidadeDocumentosQualidade> autoavaliacaoGerencialSGQList = new List<TaxaConformidadeDocumentosQualidade>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var autoavaliacaoGerencialSGQCount = _autoavaliacaoGerencialSGQDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id).Result.Any();
            var anoTaxaConformidadeDocumentosQualidadeList = _autoavaliacaoGerencialSGQDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id).Result.ToList();
            var anoMetalList = _autoavaliacaoGerencialSGQMetaDomainService.GetAllAsync().Result.ToList();
            

            if (usuarioLogado.IsTaxaConformidadeDocumentosQualidade)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoTaxaConformidadeDocumentosQualidadeList.Any(x => x.Ano1 == ano.Ano1 && x.Ano2 == ano.Ano2))
                    {
                        for (int i = 1; i <= 4; i++)
                        {
                            TaxaConformidadeDocumentosQualidade autoavaliacaoGerencialSGQ = new TaxaConformidadeDocumentosQualidade
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano1 = ano.Ano1,
                                Ano2 = ano.Ano2,
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_TaxaConformidadeDocumentosQualidade").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Autoavaliação Gerencial SGQ para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _autoavaliacaoGerencialSGQDomainService.AddListAsync(autoavaliacaoGerencialSGQList);

                transaction.Complete();

            }
        }


        public async Task<TaxaConformidadeDocumentosQualidadeResponseDTO> UpdateAsync(long id, TaxaConformidadeDocumentosQualidadeRequestDTO request)
        {
            var model = _mapper.Map<TaxaConformidadeDocumentosQualidade>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_TaxaConformidadeDocumentosQualidade");

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

                    var result = await _autoavaliacaoGerencialSGQDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<TaxaConformidadeDocumentosQualidadeResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }



        public async Task<TaxaConformidadeDocumentosQualidadeResponseDTO> DeleteAsync(long id)
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
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_TaxaConformidadeDocumentosQualidade".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Autoavaliação Gerencial SGQ de responsabilidade {model.UsuarioCadastro.Nome} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _autoavaliacaoGerencialSGQDomainService.DeleteAsync(id);

            return _mapper.Map<TaxaConformidadeDocumentosQualidadeResponseDTO>(result);

        }

        public async Task<TaxaConformidadeDocumentosQualidadeResponseDTO> GetByIdAsync(long id)
        {
            var result = await _autoavaliacaoGerencialSGQDomainService.GetByIdAsync(id);
            return _mapper.Map<TaxaConformidadeDocumentosQualidadeResponseDTO>(result);
        }


        public async Task<List<TaxaConformidadeDocumentosQualidadeResponseDTO>> GetAllAsync()
        {
            var result = await _autoavaliacaoGerencialSGQDomainService.GetAllAsync();

            return _mapper.Map<List<TaxaConformidadeDocumentosQualidadeResponseDTO>>(result);
        }
        public async Task<List<TaxaConformidadeDocumentosQualidadeResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _autoavaliacaoGerencialSGQDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            return _mapper.Map<List<TaxaConformidadeDocumentosQualidadeResponseDTO>>(result);
        }

        public async Task<List<TaxaConformidadeDocumentosQualidadeResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _autoavaliacaoGerencialSGQDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<TaxaConformidadeDocumentosQualidadeResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(TaxaConformidadeDocumentosQualidadeRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());


            //Log de diferenças
            if (request.Id != 0)
            {
                TaxaConformidadeDocumentosQualidade requestOld = _mapper.Map<TaxaConformidadeDocumentosQualidade>(GetByIdAsync(request.Id).Result);
                TaxaConformidadeDocumentosQualidade requestNew = _mapper.Map<TaxaConformidadeDocumentosQualidade>(request);

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
            _autoavaliacaoGerencialSGQDomainService.Dispose();
        }


    }
}
