using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EficaciaTreinamentoMetaController : ControllerBase
    {
        private readonly IEficaciaTreinamentoMetaAppService _eficaciaTreinamentoMetaAppService;

        public EficaciaTreinamentoMetaController(IEficaciaTreinamentoMetaAppService eficaciaTreinamentoMetaAppService)
        {
            _eficaciaTreinamentoMetaAppService = eficaciaTreinamentoMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EficaciaTreinamentoMetaResponseDTO),201)]
        public async Task<IActionResult> AddAsync([FromBody] EficaciaTreinamentoMetaRequestDTO request)
        {
            var response = await _eficaciaTreinamentoMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EficaciaTreinamentoMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] EficaciaTreinamentoMetaRequestDTO request)
        {
            var response = await _eficaciaTreinamentoMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EficaciaTreinamentoMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _eficaciaTreinamentoMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(EficaciaTreinamentoMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _eficaciaTreinamentoMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<EficaciaTreinamentoMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _eficaciaTreinamentoMetaAppService.GetAllAsync();

            return Ok(response);
        }

        
        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<EficaciaTreinamentoMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _eficaciaTreinamentoMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
