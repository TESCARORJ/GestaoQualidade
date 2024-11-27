using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.API.Helpers;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.SqlServer.Repositories;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _UsuarioAppService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UsuarioController(IUsuarioAppService UsuarioAppService, IHttpContextAccessor httpContextAccessor)
        {
            _UsuarioAppService = UsuarioAppService;
            _httpContextAccessor = httpContextAccessor;
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


    }
}
