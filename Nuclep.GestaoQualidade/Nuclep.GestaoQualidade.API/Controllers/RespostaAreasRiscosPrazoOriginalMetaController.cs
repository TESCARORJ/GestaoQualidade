using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespostaAreasRiscosPrazoOriginalMetaController : ControllerBase
    {
        private readonly IRespostaAreasRiscosPrazoOriginalMetaAppService _respostaAreasRiscosPrazoOriginalMetaAppService;

        public RespostaAreasRiscosPrazoOriginalMetaController(IRespostaAreasRiscosPrazoOriginalMetaAppService respostaAreasRiscosPrazoOriginalMetaAppService)
        {
            _respostaAreasRiscosPrazoOriginalMetaAppService = respostaAreasRiscosPrazoOriginalMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RespostaAreasRiscosPrazoOriginalMetaResponseDTO),201)]
        public async Task<IActionResult> AddAsync([FromBody] RespostaAreasRiscosPrazoOriginalMetaRequestDTO request)
        {
            var response = await _respostaAreasRiscosPrazoOriginalMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RespostaAreasRiscosPrazoOriginalMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] RespostaAreasRiscosPrazoOriginalMetaRequestDTO request)
        {
            var response = await _respostaAreasRiscosPrazoOriginalMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RespostaAreasRiscosPrazoOriginalMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _respostaAreasRiscosPrazoOriginalMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(RespostaAreasRiscosPrazoOriginalMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _respostaAreasRiscosPrazoOriginalMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<RespostaAreasRiscosPrazoOriginalMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _respostaAreasRiscosPrazoOriginalMetaAppService.GetAllAsync();

            return Ok(response);
        }

        
        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<RespostaAreasRiscosPrazoOriginalMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _respostaAreasRiscosPrazoOriginalMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
