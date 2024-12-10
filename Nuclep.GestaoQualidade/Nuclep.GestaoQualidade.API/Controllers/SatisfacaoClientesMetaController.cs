using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatisfacaoClientesMetaController : ControllerBase
    {
        private readonly ISatisfacaoClientesMetaAppService _satisfacaoClientesMetaAppService;

        public SatisfacaoClientesMetaController(ISatisfacaoClientesMetaAppService satisfacaoClientesMetaAppService)
        {
            _satisfacaoClientesMetaAppService = satisfacaoClientesMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SatisfacaoClientesMetaResponseDTO), 201)]
        public async Task<IActionResult> AddAsync([FromBody] SatisfacaoClientesMetaRequestDTO request)
        {
            var response = await _satisfacaoClientesMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SatisfacaoClientesMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] SatisfacaoClientesMetaRequestDTO request)
        {
            var response = await _satisfacaoClientesMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SatisfacaoClientesMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _satisfacaoClientesMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(SatisfacaoClientesMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _satisfacaoClientesMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<SatisfacaoClientesMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _satisfacaoClientesMetaAppService.GetAllAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<SatisfacaoClientesMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _satisfacaoClientesMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
