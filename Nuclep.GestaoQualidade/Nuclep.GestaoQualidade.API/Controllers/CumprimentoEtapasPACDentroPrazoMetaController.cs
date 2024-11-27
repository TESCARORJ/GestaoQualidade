using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CumprimentoEtapasPACDentroPrazoMetaController : ControllerBase
    {
        private readonly ICumprimentoEtapasPACDentroPrazoMetaAppService _cumprimentoEtapasPACDentroPrazoMetaAppService;

        public CumprimentoEtapasPACDentroPrazoMetaController(ICumprimentoEtapasPACDentroPrazoMetaAppService cumprimentoEtapasPACDentroPrazoMetaAppService)
        {
            _cumprimentoEtapasPACDentroPrazoMetaAppService = cumprimentoEtapasPACDentroPrazoMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CumprimentoEtapasPACDentroPrazoMetaResponseDTO),201)]
        public async Task<IActionResult> AddAsync([FromBody] CumprimentoEtapasPACDentroPrazoMetaRequestDTO request)
        {
            var response = await _cumprimentoEtapasPACDentroPrazoMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CumprimentoEtapasPACDentroPrazoMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] CumprimentoEtapasPACDentroPrazoMetaRequestDTO request)
        {
            var response = await _cumprimentoEtapasPACDentroPrazoMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CumprimentoEtapasPACDentroPrazoMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _cumprimentoEtapasPACDentroPrazoMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(CumprimentoEtapasPACDentroPrazoMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _cumprimentoEtapasPACDentroPrazoMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _cumprimentoEtapasPACDentroPrazoMetaAppService.GetAllAsync();

            return Ok(response);
        }

        
        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _cumprimentoEtapasPACDentroPrazoMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
