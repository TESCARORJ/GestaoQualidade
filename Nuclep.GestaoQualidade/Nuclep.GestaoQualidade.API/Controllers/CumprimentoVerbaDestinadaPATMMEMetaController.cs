using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CumprimentoVerbaDestinadaPATMMEMetaController : ControllerBase
    {
        private readonly ICumprimentoVerbaDestinadaPATMMEMetaAppService _cumprimentoVerbaDestinadaPATMMEMetaAppService;

        public CumprimentoVerbaDestinadaPATMMEMetaController(ICumprimentoVerbaDestinadaPATMMEMetaAppService cumprimentoVerbaDestinadaPATMMEMetaAppService)
        {
            _cumprimentoVerbaDestinadaPATMMEMetaAppService = cumprimentoVerbaDestinadaPATMMEMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CumprimentoVerbaDestinadaPATMMEMetaResponseDTO),201)]
        public async Task<IActionResult> AddAsync([FromBody] CumprimentoVerbaDestinadaPATMMEMetaRequestDTO request)
        {
            var response = await _cumprimentoVerbaDestinadaPATMMEMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CumprimentoVerbaDestinadaPATMMEMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] CumprimentoVerbaDestinadaPATMMEMetaRequestDTO request)
        {
            var response = await _cumprimentoVerbaDestinadaPATMMEMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CumprimentoVerbaDestinadaPATMMEMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _cumprimentoVerbaDestinadaPATMMEMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(CumprimentoVerbaDestinadaPATMMEMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _cumprimentoVerbaDestinadaPATMMEMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _cumprimentoVerbaDestinadaPATMMEMetaAppService.GetAllAsync();

            return Ok(response);
        }

        
        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _cumprimentoVerbaDestinadaPATMMEMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
