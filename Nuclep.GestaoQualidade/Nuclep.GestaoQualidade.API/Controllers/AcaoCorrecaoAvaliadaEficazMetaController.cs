using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcaoCorrecaoAvaliadaEficazMetaController : ControllerBase
    {
        private readonly IAcaoCorrecaoAvaliadaEficazMetaAppService _acaoCorrecaoAvaliadaEficazMetaAppService;

        public AcaoCorrecaoAvaliadaEficazMetaController(IAcaoCorrecaoAvaliadaEficazMetaAppService acaoCorrecaoAvaliadaEficazMetaAppService)
        {
            _acaoCorrecaoAvaliadaEficazMetaAppService = acaoCorrecaoAvaliadaEficazMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AcaoCorrecaoAvaliadaEficazMetaResponseDTO),201)]
        public async Task<IActionResult> AddAsync([FromBody] AcaoCorrecaoAvaliadaEficazMetaRequestDTO request)
        {
            var response = await _acaoCorrecaoAvaliadaEficazMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AcaoCorrecaoAvaliadaEficazMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] AcaoCorrecaoAvaliadaEficazMetaRequestDTO request)
        {
            var response = await _acaoCorrecaoAvaliadaEficazMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AcaoCorrecaoAvaliadaEficazMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _acaoCorrecaoAvaliadaEficazMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(AcaoCorrecaoAvaliadaEficazMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _acaoCorrecaoAvaliadaEficazMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<AcaoCorrecaoAvaliadaEficazMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _acaoCorrecaoAvaliadaEficazMetaAppService.GetAllAsync();

            return Ok(response);
        }

        
        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<AcaoCorrecaoAvaliadaEficazMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _acaoCorrecaoAvaliadaEficazMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
