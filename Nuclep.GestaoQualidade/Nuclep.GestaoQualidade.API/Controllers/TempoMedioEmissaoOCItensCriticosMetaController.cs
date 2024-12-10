using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempoMedioEmissaoOCItensCriticosMetaController : ControllerBase
    {
        private readonly ITempoMedioEmissaoOCItensCriticosMetaAppService _tempoMedioEmissaoOCItensCriticosMetaAppService;

        public TempoMedioEmissaoOCItensCriticosMetaController(ITempoMedioEmissaoOCItensCriticosMetaAppService tempoMedioEmissaoOCItensCriticosMetaAppService)
        {
            _tempoMedioEmissaoOCItensCriticosMetaAppService = tempoMedioEmissaoOCItensCriticosMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TempoMedioEmissaoOCItensCriticosMetaResponseDTO), 201)]
        public async Task<IActionResult> AddAsync([FromBody] TempoMedioEmissaoOCItensCriticosMetaRequestDTO request)
        {
            var response = await _tempoMedioEmissaoOCItensCriticosMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TempoMedioEmissaoOCItensCriticosMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] TempoMedioEmissaoOCItensCriticosMetaRequestDTO request)
        {
            var response = await _tempoMedioEmissaoOCItensCriticosMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TempoMedioEmissaoOCItensCriticosMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _tempoMedioEmissaoOCItensCriticosMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(TempoMedioEmissaoOCItensCriticosMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _tempoMedioEmissaoOCItensCriticosMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<TempoMedioEmissaoOCItensCriticosMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _tempoMedioEmissaoOCItensCriticosMetaAppService.GetAllAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<TempoMedioEmissaoOCItensCriticosMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _tempoMedioEmissaoOCItensCriticosMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
