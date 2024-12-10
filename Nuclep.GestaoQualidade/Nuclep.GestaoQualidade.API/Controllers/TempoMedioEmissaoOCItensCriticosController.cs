using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Application.Interfaces.Sistema;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempoMedioEmissaoOCItensCriticosController : ControllerBase
    {
        private readonly ITempoMedioEmissaoOCItensCriticosAppService _tempoMedioEmissaoOCItensCriticosAppService;
        private readonly ITempoMedioEmissaoOCItensCriticosMetaDomainService _tempoMedioEmissaoOCItensCriticosMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public TempoMedioEmissaoOCItensCriticosController(
            ITempoMedioEmissaoOCItensCriticosAppService tempoMedioEmissaoOCItensCriticosAppService,
            ITempoMedioEmissaoOCItensCriticosMetaDomainService tempoMedioEmissaoOCItensCriticosMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _tempoMedioEmissaoOCItensCriticosAppService = tempoMedioEmissaoOCItensCriticosAppService;
            _tempoMedioEmissaoOCItensCriticosMetaDomainService = tempoMedioEmissaoOCItensCriticosMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }




        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _tempoMedioEmissaoOCItensCriticosMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(TempoMedioEmissaoOCItensCriticosResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntas()
        {
           await _tempoMedioEmissaoOCItensCriticosAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TempoMedioEmissaoOCItensCriticosResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] TempoMedioEmissaoOCItensCriticosRequestDTO request)
        {
            var response = await _tempoMedioEmissaoOCItensCriticosAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TempoMedioEmissaoOCItensCriticosResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _tempoMedioEmissaoOCItensCriticosAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(TempoMedioEmissaoOCItensCriticosResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _tempoMedioEmissaoOCItensCriticosAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<TempoMedioEmissaoOCItensCriticosResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _tempoMedioEmissaoOCItensCriticosAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<TempoMedioEmissaoOCItensCriticosResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _tempoMedioEmissaoOCItensCriticosAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<TempoMedioEmissaoOCItensCriticosResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _tempoMedioEmissaoOCItensCriticosAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
