using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatisfacaoUsuarioMetaController : ControllerBase
    {
        private readonly ISatisfacaoUsuarioMetaAppService _satisfacaoUsuarioMetaAppService;

        public SatisfacaoUsuarioMetaController(ISatisfacaoUsuarioMetaAppService satisfacaoUsuarioMetaAppService)
        {
            _satisfacaoUsuarioMetaAppService = satisfacaoUsuarioMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SatisfacaoUsuarioMetaResponseDTO), 201)]
        public async Task<IActionResult> AddAsync([FromBody] SatisfacaoUsuarioMetaRequestDTO request)
        {
            var response = await _satisfacaoUsuarioMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SatisfacaoUsuarioMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] SatisfacaoUsuarioMetaRequestDTO request)
        {
            var response = await _satisfacaoUsuarioMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SatisfacaoUsuarioMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _satisfacaoUsuarioMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(SatisfacaoUsuarioMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _satisfacaoUsuarioMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<SatisfacaoUsuarioMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _satisfacaoUsuarioMetaAppService.GetAllAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<SatisfacaoUsuarioMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _satisfacaoUsuarioMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
