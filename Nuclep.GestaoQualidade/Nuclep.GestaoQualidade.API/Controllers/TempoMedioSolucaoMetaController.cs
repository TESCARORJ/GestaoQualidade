using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempoMedioSolucaoMetaController : ControllerBase
    {
        private readonly ITempoMedioSolucaoMetaAppService _tempoMedioSolucaoMetaAppService;

        public TempoMedioSolucaoMetaController(ITempoMedioSolucaoMetaAppService tempoMedioSolucaoMetaAppService)
        {
            _tempoMedioSolucaoMetaAppService = tempoMedioSolucaoMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TempoMedioSolucaoMetaResponseDTO), 201)]
        public async Task<IActionResult> AddAsync([FromBody] TempoMedioSolucaoMetaRequestDTO request)
        {
            var response = await _tempoMedioSolucaoMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TempoMedioSolucaoMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] TempoMedioSolucaoMetaRequestDTO request)
        {
            var response = await _tempoMedioSolucaoMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TempoMedioSolucaoMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _tempoMedioSolucaoMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(TempoMedioSolucaoMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _tempoMedioSolucaoMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<TempoMedioSolucaoMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _tempoMedioSolucaoMetaAppService.GetAllAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<TempoMedioSolucaoMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _tempoMedioSolucaoMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
