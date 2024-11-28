﻿using AutoMapper;
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
        private readonly IEficaciaTreinamentoRepository _eficaciaTreinamentoRepository;


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
            IEficaciaTreinamentoRepository eficaciaTreinamentoRepository)
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
        }

        //[HttpPost("{AddForm}")]
        //[ProducesResponseType(typeof(UsuarioResponseDTO),201)]
        //public async Task<IActionResult> AddFormAsync([FromBody] UsuarioRequestDTO request)
        //{
        //    var response = await _UsuarioAppService.AddAsync(request);

        //    return StatusCode(201, response);
        //}

        //[HttpPost]
        //[ProducesResponseType(typeof(UsuarioResponseDTO),201)]
        //public async Task<IActionResult> AddAsync(UsuarioRequestDTO request)
        //{
        //    var response = await _UsuarioAppService.AddAsync(request);

        //    return StatusCode(201, response);
        //}

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
            request.IsGestaoProcessosPessoasPrevistoPAT = false;
            request.IsItensCadastradosMais15Dias = false;
            request.IsLocalidadeAramar = false;
            request.IsLocalidadeItaguai = false;
            request.IsNivelServicoAtendimento = false;
            request.IsOcupacaoMaoObra = false;
            request.IsProdutividadeMaoObra = false;
            request.IsReducaoRNC = false;
            request.IsRespostaAreasPrazoOriginal = false;
            request.IsRetrabalhoDocumentos = false;
            request.IsSatisfacaoClientesAreaResponsavel = false;
            request.IsSatisfacaoUsuario = false;
            request.IsTaxaConformidadeDocumentosQualidade = false;
            request.IsTempoManutencaoCorretivaEquipamentoProgramado = false;
            request.IsTempoMedioInspecaoRecebimentoMateriais = false;
            request.IsTempoMedioSolucao = false;
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
                                Descricao = $"Deletados períodos do Indicador Autoavalização Gerencial SGQ para o usuário {usuario.Nome} em {DateTime.Now}",
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

