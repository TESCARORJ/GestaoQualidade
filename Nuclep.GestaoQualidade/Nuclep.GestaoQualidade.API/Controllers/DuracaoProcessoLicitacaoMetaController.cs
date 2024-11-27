using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuracaoProcessoLicitacaoMetaController : ControllerBase
    {
        private readonly IDuracaoProcessoLicitacaoMetaAppService _duracaoProcessoLicitacaoMetaAppService;

        public DuracaoProcessoLicitacaoMetaController(IDuracaoProcessoLicitacaoMetaAppService duracaoProcessoLicitacaoMetaAppService)
        {
            _duracaoProcessoLicitacaoMetaAppService = duracaoProcessoLicitacaoMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(DuracaoProcessoLicitacaoMetaResponseDTO),201)]
        public async Task<IActionResult> AddAsync([FromBody] DuracaoProcessoLicitacaoMetaRequestDTO request)
        {
            var response = await _duracaoProcessoLicitacaoMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DuracaoProcessoLicitacaoMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] DuracaoProcessoLicitacaoMetaRequestDTO request)
        {
            var response = await _duracaoProcessoLicitacaoMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DuracaoProcessoLicitacaoMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _duracaoProcessoLicitacaoMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(DuracaoProcessoLicitacaoMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _duracaoProcessoLicitacaoMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<DuracaoProcessoLicitacaoMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _duracaoProcessoLicitacaoMetaAppService.GetAllAsync();

            return Ok(response);
        }

        
        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<DuracaoProcessoLicitacaoMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _duracaoProcessoLicitacaoMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
