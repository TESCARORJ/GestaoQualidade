using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RejeicaoMateriaisMetaController : ControllerBase
    {
        private readonly IRejeicaoMateriaisMetaAppService _rejeicaoMateriaisMetaAppService;

        public RejeicaoMateriaisMetaController(IRejeicaoMateriaisMetaAppService rejeicaoMateriaisMetaAppService)
        {
            _rejeicaoMateriaisMetaAppService = rejeicaoMateriaisMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(RejeicaoMateriaisMetaResponseDTO),201)]
        public async Task<IActionResult> AddAsync([FromBody] RejeicaoMateriaisMetaRequestDTO request)
        {
            var response = await _rejeicaoMateriaisMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RejeicaoMateriaisMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] RejeicaoMateriaisMetaRequestDTO request)
        {
            var response = await _rejeicaoMateriaisMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RejeicaoMateriaisMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _rejeicaoMateriaisMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(RejeicaoMateriaisMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _rejeicaoMateriaisMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<RejeicaoMateriaisMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _rejeicaoMateriaisMetaAppService.GetAllAsync();

            return Ok(response);
        }

        
        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<RejeicaoMateriaisMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _rejeicaoMateriaisMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
