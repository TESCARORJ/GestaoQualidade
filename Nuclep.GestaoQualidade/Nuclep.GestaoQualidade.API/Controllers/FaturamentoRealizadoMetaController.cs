using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaturamentoRealizadoMetaController : ControllerBase
    {
        private readonly IFaturamentoRealizadoMetaAppService _faturamentoRealizadoMetaAppService;

        public FaturamentoRealizadoMetaController(IFaturamentoRealizadoMetaAppService faturamentoRealizadoMetaAppService)
        {
            _faturamentoRealizadoMetaAppService = faturamentoRealizadoMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(FaturamentoRealizadoMetaResponseDTO),201)]
        public async Task<IActionResult> AddAsync([FromBody] FaturamentoRealizadoMetaRequestDTO request)
        {
            var response = await _faturamentoRealizadoMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FaturamentoRealizadoMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] FaturamentoRealizadoMetaRequestDTO request)
        {
            var response = await _faturamentoRealizadoMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FaturamentoRealizadoMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _faturamentoRealizadoMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(FaturamentoRealizadoMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _faturamentoRealizadoMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<FaturamentoRealizadoMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _faturamentoRealizadoMetaAppService.GetAllAsync();

            return Ok(response);
        }

        
        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<FaturamentoRealizadoMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _faturamentoRealizadoMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
