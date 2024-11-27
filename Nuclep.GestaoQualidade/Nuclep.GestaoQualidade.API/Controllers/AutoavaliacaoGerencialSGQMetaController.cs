using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoavaliacaoGerencialSGQMetaController : ControllerBase
    {
        private readonly IAutoavaliacaoGerencialSGQMetaAppService _autoavaliacaoGerencialSGQMetaAppService;

        public AutoavaliacaoGerencialSGQMetaController(IAutoavaliacaoGerencialSGQMetaAppService autoavaliacaoGerencialSGQMetaAppService)
        {
            _autoavaliacaoGerencialSGQMetaAppService = autoavaliacaoGerencialSGQMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AutoavaliacaoGerencialSGQMetaResponseDTO),201)]
        public async Task<IActionResult> AddAsync([FromBody] AutoavaliacaoGerencialSGQMetaRequestDTO request)
        {
            var response = await _autoavaliacaoGerencialSGQMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AutoavaliacaoGerencialSGQMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] AutoavaliacaoGerencialSGQMetaRequestDTO request)
        {
            var response = await _autoavaliacaoGerencialSGQMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AutoavaliacaoGerencialSGQMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _autoavaliacaoGerencialSGQMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(AutoavaliacaoGerencialSGQMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _autoavaliacaoGerencialSGQMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<AutoavaliacaoGerencialSGQMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _autoavaliacaoGerencialSGQMetaAppService.GetAllAsync();

            return Ok(response);
        }

        
        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<AutoavaliacaoGerencialSGQMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _autoavaliacaoGerencialSGQMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
