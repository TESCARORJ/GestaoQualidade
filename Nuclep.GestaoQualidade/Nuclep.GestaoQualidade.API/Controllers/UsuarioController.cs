using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.SqlServer.Repositories;
using System.Transactions;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _UsuarioAppService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IMapper _mapper;
        private readonly IDefeitoSoldagemRepository _defeitoSoldagemRepository;
        private readonly IAcaoCorrecaoAvaliadaEficazRepository _acaoCorrecaoAvaliadaEficazRepository;
        private readonly IAderenciaProgramacaoMensalRepository _aderenciaProgramacaoMensalRepository;
        private readonly IAutoavaliacaoGerencialSGQRepository _autoavaliacaoGerencialSGQRepository;
        private readonly ICumprimentoEtapasPACDentroPrazoRepository _cumprimentoEtapasPACDentroPrazoRepository;
        private readonly ICumprimentoVerbaDestinadaPATMMERepository _cumprimentoVerbaDestinadaPATMMERepository;
        private readonly IDuracaoProcessoLicitacaoRepository _duracaoProcessoLicitacaoRepository;
        private readonly IFaturamentoRealizadoRepository _faturamentoRealizadoRepository;
        private readonly IRejeicaoMateriaisRepository _rejeicaoMateriaisRepository;
        private readonly IRespostaAreasRiscosPrazoOriginalRepository _respostaAreasRiscosPrazoOriginalRepository;
        private readonly IEficaciaTreinamentoRepository _eficaciaTreinamentoRepository;
        private readonly IOcupacaoMaoObraRepository _ocupacaoMaoObraRepository;
        private readonly IProdutividadeMaoObraRepository _produtividadeMaoObraRepository;
        private readonly ISatisfacaoClientesRepository _satisfacaoClientesRepository;
        private readonly ISatisfacaoUsuarioRepository _satisfacaoUsuarioRepository;
        private readonly INaoConformidadeRepository _naoConformidadeRepository;
        private readonly ITempoMedioSolucaoRepository _tempoMedioSolucaoRepository;
        private readonly ITempoReparoEquipamentosProgramadosObrasRepository _tempoReparoEquipamentosProgramadosObrasRepository;


        public UsuarioController(
            IUsuarioAppService UsuarioAppService,
            IHttpContextAccessor httpContextAccessor,
            IDefeitoSoldagemRepository defeitoSoldagemRepository,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IMapper mapper,
            IAcaoCorrecaoAvaliadaEficazRepository acaoCorrecaoAvaliadaEficazRepository,
            IAderenciaProgramacaoMensalRepository aderenciaProgramacaoMensalRepository,
            IAutoavaliacaoGerencialSGQRepository autoavaliacaoGerencialSGQRepository,
            ICumprimentoEtapasPACDentroPrazoRepository cumprimentoEtapasPACDentroPrazoRepository,
            ICumprimentoVerbaDestinadaPATMMERepository cumprimentoVerbaDestinadaPATMMERepository,
            IDuracaoProcessoLicitacaoRepository duracaoProcessoLicitacaoRepository,
            IFaturamentoRealizadoRepository faturamentoRealizadoRepository,
            IEficaciaTreinamentoRepository eficaciaTreinamentoRepository,
            IOcupacaoMaoObraRepository ocupacaoMaoObraRepository,
            IProdutividadeMaoObraRepository produtividadeMaoObraRepository,
            IRejeicaoMateriaisRepository rejeicaoMateriaisRepository,
            ISatisfacaoClientesRepository satisfacaoClientesRepository,
            ISatisfacaoUsuarioRepository satisfacaoUsuarioRepository,
            INaoConformidadeRepository naoConformidadeRepository,
            ITempoMedioSolucaoRepository tempoMedioSolucaoRepository,
            ITempoReparoEquipamentosProgramadosObrasRepository tempoReparoEquipamentosProgramadosObrasRepository)
        {
            _UsuarioAppService = UsuarioAppService;
            _httpContextAccessor = httpContextAccessor;
            _defeitoSoldagemRepository = defeitoSoldagemRepository;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _mapper = mapper;
            _acaoCorrecaoAvaliadaEficazRepository = acaoCorrecaoAvaliadaEficazRepository;
            _aderenciaProgramacaoMensalRepository = aderenciaProgramacaoMensalRepository;
            _autoavaliacaoGerencialSGQRepository = autoavaliacaoGerencialSGQRepository;
            _cumprimentoEtapasPACDentroPrazoRepository = cumprimentoEtapasPACDentroPrazoRepository;
            _cumprimentoVerbaDestinadaPATMMERepository = cumprimentoVerbaDestinadaPATMMERepository;
            _duracaoProcessoLicitacaoRepository = duracaoProcessoLicitacaoRepository;
            _faturamentoRealizadoRepository = faturamentoRealizadoRepository;
            _eficaciaTreinamentoRepository = eficaciaTreinamentoRepository;
            _ocupacaoMaoObraRepository = ocupacaoMaoObraRepository;
            _produtividadeMaoObraRepository = produtividadeMaoObraRepository;
            _rejeicaoMateriaisRepository = rejeicaoMateriaisRepository;
            _satisfacaoClientesRepository = satisfacaoClientesRepository;
            _satisfacaoUsuarioRepository = satisfacaoUsuarioRepository;
            _naoConformidadeRepository = naoConformidadeRepository;
            _tempoMedioSolucaoRepository = tempoMedioSolucaoRepository;
            _tempoReparoEquipamentosProgramadosObrasRepository = tempoReparoEquipamentosProgramadosObrasRepository;
        }


        private void LimparIndicadores(UsuarioRequestDTO request)
        {
            request.IsAcaoCorrecaoAvaliadaEficaz = false;
            request.IsCumprimentoVerbaDestinadaPATMME = false;
            request.IsAcaoDentroPrazo = false;
            request.IsAderenciaProgramacaoMensal = false;
            request.IsCumprimentoEtapasPACDentroPrazo = false;
            request.IsAutoavaliacaoGerencialSGQ = false;
            request.IsCapacitacaoAreaContratos = false;
            request.IsCondensador = false;
            request.IsDuracaoProcessoLicitacao = false;
            request.IsEventosAtraso = false;
            request.IsFaturamentoRealizado = false;
            request.IsRejeicaoMateriais = false;
            request.IsRespostaAreasRiscosPrazoOriginal = false;
            request.IsGestaoProcessosPessoasPrevistoPAT = false;
            request.IsItensCadastradosMais15Dias = false;
            request.IsLocalidadeAramar = false;
            request.IsLocalidadeItaguai = false;
            request.IsNivelServicoAtendimento = false;
            request.IsOcupacaoMaoObra = false;
            request.IsProdutividadeMaoObra = false;
            request.IsSatisfacaoClientes = false;
            request.IsTempoMedioEmissaoOCItensCriticos = false;
            request.IsReducaoRNC = false;
            request.IsRespostaAreasPrazoOriginal = false;
            request.IsRetrabalhoDocumentos = false;
            request.IsSatisfacaoClientesAreaResponsavel = false;
            request.IsSatisfacaoUsuario = false;
            request.IsTaxaConformidadeDocumentosQualidade = false;
            request.IsTempoManutencaoCorretivaEquipamentoProgramado = false;
            request.IsTempoMedioInspecaoRecebimentoMateriais = false;
            request.IsTempoMedioSolucao = false;
            request.IsServiceLevelAgreement = false;
            request.IsNaoConformidade = false;
            request.IsTempoReparoEquipamentosProgramadosObras = false;
            request.IsVPR = false;
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UsuarioResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] UsuarioRequestDTO request)
        {

            if (request.IsConfirmacaoNaoInformado)
            {
                LimparIndicadores(request);
            }

            var usuario = _mapper.Map<Usuario>(request);

            await DeletePerguntasAsync(usuario);

            var response = await _UsuarioAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UsuarioResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _UsuarioAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(UsuarioResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _UsuarioAppService.GetByIdAsync(id);

            if (response == null)
            {
                return NotFound("Usuário não existe ou não foi encontrado");
            }

            return Ok(response);
        }

        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(UsuarioResponseDTO), 200)]
        public async Task<IActionResult> GetByNameListAsync(string nome)
        {
            var response = await _UsuarioAppService.GetByNameListAsync(nome);

            if (response == null)
            {
                return NotFound("Usuário não existe ou não foi encontrado");
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<UsuarioResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _UsuarioAppService.GetAllAsync();


            if (response == null)
            {
                return NotFound("Nenhum usuário localizado");
            }


            return Ok(response);
        }

        [HttpGet("ExisteUsuario")]
        public async Task<bool> ExisteUsuario(string nomeAD)
        {
            var response = await _UsuarioAppService.ExisteUsuario(nomeAD);

            return response;
        }

        [HttpGet]
        [Route("PerfilAdim")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> PerfilAdim(string login)
        {
            var isPerfilSistema = await _UsuarioAppService.GetByLoginAsync(login);

            if (isPerfilSistema.PerfilSistema == Enums.Administrador)
            {
                return Ok(isPerfilSistema);
            }

            return NotFound();


        }

        [HttpGet]
        [Route("Usuario")]
        [ProducesResponseType(typeof(UsuarioResponseDTO), 201)]
        public async Task<IActionResult> Usuario(string login)
        {
            var isPerfilSistema = await _UsuarioAppService.GetByLoginAsync(login);
            return Ok(isPerfilSistema);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task DeletePerguntasAsync(Usuario usuario)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {

                    #region AcaoCorrecaoAvaliadaEficaz

                    if (!usuario.IsAcaoCorrecaoAvaliadaEficaz)
                    {
                        var acaoCorrecaoAvaliadaEficazList = await _acaoCorrecaoAvaliadaEficazRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (acaoCorrecaoAvaliadaEficazList.Count > 0)
                        {
                            var logAcaoCorrecaoAvaliadaEficaz = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_AcaoCorrecaoAvaliadaEficaz").Result.Id,
                                Descricao = $"Deletados períodos do Indicador Ação Correção Avalizada Eficaz para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logAcaoCorrecaoAvaliadaEficaz);

                            foreach (var acaoCorrecaoAvaliada in acaoCorrecaoAvaliadaEficazList)
                            {
                                await _acaoCorrecaoAvaliadaEficazRepository.DeleteAsync(acaoCorrecaoAvaliada);

                            }

                        }
                    }



                    #endregion

                    #region AderenciaProgramacaoMensal

                    if (!usuario.IsAderenciaProgramacaoMensal)
                    {
                        var aderenciaProgramacaoMensalList = await _aderenciaProgramacaoMensalRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (aderenciaProgramacaoMensalList.Count > 0)
                        {
                            var logAderenciaProgramacaoMensal = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_AderenciaProgramacaoMensal").Result.Id,
                                Descricao = $"Deletados períodos do Indicador Aderência Programação Mensal para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logAderenciaProgramacaoMensal);

                            foreach (var acaoCorrecaoAvaliada in aderenciaProgramacaoMensalList)
                            {
                                await _aderenciaProgramacaoMensalRepository.DeleteAsync(acaoCorrecaoAvaliada);

                            }

                        }
                    }

                    #endregion

                    #region AutoavaliacaoGerencialSGQ

                    if (!usuario.IsAutoavaliacaoGerencialSGQ)
                    {
                        var autoavaliacaoGerencialSGQList = await _autoavaliacaoGerencialSGQRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (autoavaliacaoGerencialSGQList.Count > 0)
                        {
                            var logAutoavaliacaoGerencialSGQ = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_AutoavaliacaoGerencialSGQ").Result.Id,
                                Descricao = $"Deletados períodos do Indicador Autoavaliação Gerencial SGQ para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logAutoavaliacaoGerencialSGQ);

                            foreach (var acaoCorrecaoAvaliada in autoavaliacaoGerencialSGQList)
                            {
                                await _autoavaliacaoGerencialSGQRepository.DeleteAsync(acaoCorrecaoAvaliada);

                            }

                        }
                    }

                    #endregion

                    #region CumprimentoEtapasPACDentroPrazo

                    if (!usuario.IsCumprimentoEtapasPACDentroPrazo)
                    {
                        var cumprimentoEtapasPACDentroPrazoList = await _cumprimentoEtapasPACDentroPrazoRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (cumprimentoEtapasPACDentroPrazoList.Count > 0)
                        {
                            var logCumprimentoEtapasPACDentroPrazo = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_CumprimentoEtapasPACDentroPrazo").Result.Id,
                                Descricao = $"Deletados períodos para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logCumprimentoEtapasPACDentroPrazo);

                            foreach (var acaoCorrecaoAvaliada in cumprimentoEtapasPACDentroPrazoList)
                            {
                                await _cumprimentoEtapasPACDentroPrazoRepository.DeleteAsync(acaoCorrecaoAvaliada);

                            }

                        }
                    }


                    #endregion

                    #region CumprimentoVerbaDestinadaPATMME

                    if (!usuario.IsCumprimentoVerbaDestinadaPATMME)
                    {
                        var cumprimentoVerbaDestinadaPATMMEList = await _cumprimentoVerbaDestinadaPATMMERepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (cumprimentoVerbaDestinadaPATMMEList.Count > 0)
                        {
                            var logCumprimentoVerbaDestinadaPATMME = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_CumprimentoVerbaDestinadaPATMME").Result.Id,
                                Descricao = $"Deletados períodos do Indicador Cumprimento da Verba Destina para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logCumprimentoVerbaDestinadaPATMME);

                            foreach (var acaoCorrecaoAvaliada in cumprimentoVerbaDestinadaPATMMEList)
                            {
                                await _cumprimentoVerbaDestinadaPATMMERepository.DeleteAsync(acaoCorrecaoAvaliada);

                            }

                        }
                    }

                    #endregion

                    #region DefeitoSoldagem

                    var localidadeIds = new Dictionary<string, long>
                    {
                        { "Itaguaí", 1 },
                        { "Aramar", 2 },
                        { "Condensador", 3 },
                        { "VPR", 4 }
                    };

                    foreach (var localidade in localidadeIds)
                    {
                        bool isLocalidade = localidade.Key switch
                        {
                            "Itaguaí" => usuario.IsLocalidadeItaguai,
                            "Aramar" => usuario.IsLocalidadeAramar,
                            "Condensador" => usuario.IsCondensador,
                            "VPR" => usuario.IsVPR,
                            _ => true
                        };

                        if (!isLocalidade)
                        {
                            var defeitoSoldagemList = await _defeitoSoldagemRepository.GetLocalidadeUsarioLogadoAsync(usuario.Id, localidade.Value);

                            if (defeitoSoldagemList.Count > 0)
                            {
                                var logDefeitoSoldagem = new LogCrud
                                {
                                    IdReferencia = usuario.Id,
                                    DataHoraCadastro = DateTime.Now,
                                    UsuarioId = usuario.Id,
                                    UsuarioNome = usuario.Nome,
                                    LogTipo = LogTipo.Cadastrado,
                                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_DefeitoSoldagem").Result.Id,
                                    Descricao = $"Deletados períodos do Indicador de Defeito de Soldagem de {localidade.Key} para o usuário {usuario.Nome} em {DateTime.Now}",
                                };

                                await _logCrudRepository.AddAsync(logDefeitoSoldagem);

                                foreach (var defeitoSoldagem in defeitoSoldagemList)
                                {
                                    await _defeitoSoldagemRepository.DeleteAsync(defeitoSoldagem);

                                }

                            }
                        }
                    }

                    #endregion

                    #region DuracaoProcessoLicitacao

                    if (!usuario.IsDuracaoProcessoLicitacao)
                    {
                        var duracaoProcessoLicitacaoList = await _duracaoProcessoLicitacaoRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (duracaoProcessoLicitacaoList.Count > 0)
                        {

                            var logDuracaoProcessoLicitacao = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_DuracaoProcessoLicitacao").Result.Id,
                                Descricao = $"Deletados períodos do Indicador Duração Processode Licitação para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logDuracaoProcessoLicitacao);

                            foreach (var duracaoProcessoLicitacao in duracaoProcessoLicitacaoList)
                            {
                                await _duracaoProcessoLicitacaoRepository.DeleteAsync(duracaoProcessoLicitacao);

                            }

                        }
                    }


                    #endregion

                    #region EficaciaTreinamento

                    if (!usuario.IsEficaciaTreinamento)
                    {
                        var eficaciaTreinamentoList = await _eficaciaTreinamentoRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (eficaciaTreinamentoList.Count > 0)
                        {
                            var logEficaciaTreinamento = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_EficaciaTreinamento").Result.Id,
                                Descricao = $"Deletados períodos do Indicador Cumprimento da Verba Destina para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logEficaciaTreinamento);

                            foreach (var acaoCorrecaoAvaliada in eficaciaTreinamentoList)
                            {
                                await _eficaciaTreinamentoRepository.DeleteAsync(acaoCorrecaoAvaliada);

                            }

                        }
                    }

                    #endregion

                    #region FaturamentoRealizado

                    if (!usuario.IsFaturamentoRealizado)
                    {
                        var faturamentoRealizadoList = await _faturamentoRealizadoRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (faturamentoRealizadoList.Count > 0)
                        {

                            var logFaturamentoRealizado = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_FaturamentoRealizado").Result.Id,
                                Descricao = $"Deletados períodos do Indicador Faturamento Realizado para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logFaturamentoRealizado);

                            foreach (var faturamentoRealizado in faturamentoRealizadoList)
                            {
                                await _faturamentoRealizadoRepository.DeleteAsync(faturamentoRealizado);

                            }

                        }
                    }

                    #endregion

                    #region NaoConformidade

                    if (!usuario.IsNaoConformidade)
                    {
                        var naoConformidadeList = await _naoConformidadeRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (naoConformidadeList.Count > 0)
                        {

                            var logNaoConformidade = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_NaoConformidade").Result.Id,
                                Descricao = $"Deletados períodos do Indicador Não Conformidade para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logNaoConformidade);

                            foreach (var naoConformidade in naoConformidadeList)
                            {
                                await _naoConformidadeRepository.DeleteAsync(naoConformidade);

                            }

                        }
                    }

                    #endregion

                    #region OcupacaoMaoObra                   

                    if (!usuario.IsOcupacaoMaoObra)
                    {
                        var ocupacaoMaoObraList = await _ocupacaoMaoObraRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (ocupacaoMaoObraList.Count > 0)
                        {
                            var logOcupacaoMaoObra = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_OcupacaoMaoObra").Result.Id,
                                Descricao = $"Deletados períodos do Indicador de Ocupação de Mão de Obra para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logOcupacaoMaoObra);

                            foreach (var ocupacaoMaoObra in ocupacaoMaoObraList)
                            {
                                await _ocupacaoMaoObraRepository.DeleteAsync(ocupacaoMaoObra);

                            }

                        }
                    }


                    #endregion

                    #region ProdutividadeMaoObra                   

                    if (!usuario.IsProdutividadeMaoObra)
                    {
                        var produtividadeMaoObraList = await _produtividadeMaoObraRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (produtividadeMaoObraList.Count > 0)
                        {
                            var logProdutividadeMaoObra = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_ProdutividadeMaoObra").Result.Id,
                                Descricao = $"Deletados períodos do Indicador de Produtividade de Mão de Obra para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logProdutividadeMaoObra);

                            foreach (var produtividadeMaoObra in produtividadeMaoObraList)
                            {
                                await _produtividadeMaoObraRepository.DeleteAsync(produtividadeMaoObra);

                            }

                        }
                    }


                    #endregion

                    #region RejeicaoMateriais

                    if (!usuario.IsRejeicaoMateriais)
                    {
                        var rejeicaoMateriaisList = await _rejeicaoMateriaisRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (rejeicaoMateriaisList.Count > 0)
                        {

                            var logRejeicaoMateriais = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_RejeicaoMateriais").Result.Id,
                                Descricao = $"Deletados períodos do Indicador Rejeição de Materiais para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logRejeicaoMateriais);

                            foreach (var rejeicaoMateriais in rejeicaoMateriaisList)
                            {
                                await _rejeicaoMateriaisRepository.DeleteAsync(rejeicaoMateriais);

                            }

                        }
                    }

                    #endregion

                    #region RespostaAreasRiscosPrazoOriginal

                    if (!usuario.IsRespostaAreasRiscosPrazoOriginal)
                    {
                        var respostaAreasRiscosPrazoOriginalList = await _respostaAreasRiscosPrazoOriginalRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (respostaAreasRiscosPrazoOriginalList.Count > 0)
                        {

                            var logRespostaAreasRiscosPrazoOriginal = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_RespostaAreasRiscosPrazoOriginal").Result.Id,
                                Descricao = $"Deletados períodos do Indicador Resposta Áreas Riscos Prazo Original para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logRespostaAreasRiscosPrazoOriginal);

                            foreach (var respostaAreasRiscosPrazoOriginal in respostaAreasRiscosPrazoOriginalList)
                            {
                                await _respostaAreasRiscosPrazoOriginalRepository.DeleteAsync(respostaAreasRiscosPrazoOriginal);

                            }

                        }
                    }

                    #endregion

                    #region SatisfacaoClientes                   

                    if (!usuario.IsSatisfacaoClientes)
                    {
                        var satisfacaoClientesList = await _satisfacaoClientesRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (satisfacaoClientesList.Count > 0)
                        {
                            var logSatisfacaoClientes = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_SatisfacaoClientes").Result.Id,
                                Descricao = $"Deletados períodos do Indicador de Satisfação de Cliente para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logSatisfacaoClientes);

                            foreach (var satisfacaoClientes in satisfacaoClientesList)
                            {
                                await _satisfacaoClientesRepository.DeleteAsync(satisfacaoClientes);

                            }

                        }
                    }


                    #endregion

                    #region SatisfacaoUsuario                   

                    if (!usuario.IsSatisfacaoUsuario)
                    {
                        var satisfacaoUsuarioList = await _satisfacaoUsuarioRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (satisfacaoUsuarioList.Count > 0)
                        {
                            var logSatisfacaoUsuario = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_SatisfacaoUsuario").Result.Id,
                                Descricao = $"Deletados períodos do Indicador de Satisfação de Cliente para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logSatisfacaoUsuario);

                            foreach (var satisfacaoUsuario in satisfacaoUsuarioList)
                            {
                                await _satisfacaoUsuarioRepository.DeleteAsync(satisfacaoUsuario);

                            }

                        }
                    }


                    #endregion

                    #region TempoMedioSalucao                   

                    if (!usuario.IsTempoMedioSolucao)
                    {
                        var tempoMedioSalucaoList = await _tempoMedioSolucaoRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (tempoMedioSalucaoList.Count > 0)
                        {
                            var logTempoMedioSalucao = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_TempoMedioSalucao").Result.Id,
                                Descricao = $"Deletados períodos do Indicador de Satisfação de Cliente para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logTempoMedioSalucao);

                            foreach (var tempoMedioSalucao in tempoMedioSalucaoList)
                            {
                                await _tempoMedioSolucaoRepository.DeleteAsync(tempoMedioSalucao);

                            }

                        }
                    }


                    #endregion

                    #region TaxaConformidadeDocumentosQualidade

                    if (!usuario.IsTaxaConformidadeDocumentosQualidade)
                    {
                        var autoavaliacaoGerencialSGQList = await _autoavaliacaoGerencialSGQRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (autoavaliacaoGerencialSGQList.Count > 0)
                        {
                            var logTaxaConformidadeDocumentosQualidade = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_TaxaConformidadeDocumentosQualidade").Result.Id,
                                Descricao = $"Deletados períodos do Indicador Taxa de Conformidade dos Documentos da Qualidade para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logTaxaConformidadeDocumentosQualidade);

                            foreach (var acaoCorrecaoAvaliada in autoavaliacaoGerencialSGQList)
                            {
                                await _autoavaliacaoGerencialSGQRepository.DeleteAsync(acaoCorrecaoAvaliada);

                            }

                        }
                    }

                    #endregion

                    #region TempoMedioEmissaoOCItensCriticos                   

                    if (!usuario.IsTempoMedioEmissaoOCItensCriticos)
                    {
                        var satisfacaoClientesList = await _satisfacaoClientesRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (satisfacaoClientesList.Count > 0)
                        {
                            var logTempoMedioEmissaoOCItensCriticos = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_TempoMedioEmissaoOCItensCriticos").Result.Id,
                                Descricao = $"Deletados períodos do Indicador de Tempo Médio de Emissao OCI de Itens Críticos para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logTempoMedioEmissaoOCItensCriticos);

                            foreach (var satisfacaoClientes in satisfacaoClientesList)
                            {
                                await _satisfacaoClientesRepository.DeleteAsync(satisfacaoClientes);

                            }

                        }
                    }


                    #endregion

                    #region TempoMedioSalucao                   

                    if (!usuario.IsTempoReparoEquipamentosProgramadosObras)
                    {
                        var tempoMedioSalucaoList = await _tempoReparoEquipamentosProgramadosObrasRepository.GetAllUsarioLogadoAsync(usuario.Id);

                        if (tempoMedioSalucaoList.Count > 0)
                        {
                            var logTempoMedioSalucao = new LogCrud
                            {
                                IdReferencia = usuario.Id,
                                DataHoraCadastro = DateTime.Now,
                                UsuarioId = usuario.Id,
                                UsuarioNome = usuario.Nome,
                                LogTipo = LogTipo.Cadastrado,
                                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_TempoMedioSalucao").Result.Id,
                                Descricao = $"Deletados períodos do Indicador de Tempo de Reparo de Equipamentos Programados para Obras para o usuário {usuario.Nome} em {DateTime.Now}",
                            };

                            await _logCrudRepository.AddAsync(logTempoMedioSalucao);

                            foreach (var tempoMedioSalucao in tempoMedioSalucaoList)
                            {
                                await _tempoReparoEquipamentosProgramadosObrasRepository.DeleteAsync(tempoMedioSalucao);

                            }

                        }
                    }


                    #endregion

                    transaction.Complete();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
    }
}

