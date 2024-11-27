using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AderenciaProgramacaoMensalMetaController : ControllerBase
    {
        private readonly IAderenciaProgramacaoMensalMetaAppService _aderenciaProgramacaoMensalMetaAppService;

        public AderenciaProgramacaoMensalMetaController(IAderenciaProgramacaoMensalMetaAppService aderenciaProgramacaoMensalMetaAppService)
        {
            _aderenciaProgramacaoMensalMetaAppService = aderenciaProgramacaoMensalMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(AderenciaProgramacaoMensalMetaResponseDTO),201)]
        public async Task<IActionResult> AddAsync([FromBody] AderenciaProgramacaoMensalMetaRequestDTO request)
        {
            var response = await _aderenciaProgramacaoMensalMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AderenciaProgramacaoMensalMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] AderenciaProgramacaoMensalMetaRequestDTO request)
        {
            var response = await _aderenciaProgramacaoMensalMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AderenciaProgramacaoMensalMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _aderenciaProgramacaoMensalMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(AderenciaProgramacaoMensalMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _aderenciaProgramacaoMensalMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<AderenciaProgramacaoMensalMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _aderenciaProgramacaoMensalMetaAppService.GetAllAsync();

            return Ok(response);
        }

        
        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<AderenciaProgramacaoMensalMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _aderenciaProgramacaoMensalMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
