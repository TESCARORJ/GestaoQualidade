using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensCadastradosMais15DiasMetaController : ControllerBase
    {
        private readonly IItensCadastradosMais15DiasMetaAppService _itensCadastradosMais15DiasMetaAppService;

        public ItensCadastradosMais15DiasMetaController(IItensCadastradosMais15DiasMetaAppService itensCadastradosMais15DiasMetaAppService)
        {
            _itensCadastradosMais15DiasMetaAppService = itensCadastradosMais15DiasMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ItensCadastradosMais15DiasMetaResponseDTO), 201)]
        public async Task<IActionResult> AddAsync([FromBody] ItensCadastradosMais15DiasMetaRequestDTO request)
        {
            var response = await _itensCadastradosMais15DiasMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ItensCadastradosMais15DiasMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] ItensCadastradosMais15DiasMetaRequestDTO request)
        {
            var response = await _itensCadastradosMais15DiasMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ItensCadastradosMais15DiasMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _itensCadastradosMais15DiasMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(ItensCadastradosMais15DiasMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _itensCadastradosMais15DiasMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<ItensCadastradosMais15DiasMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _itensCadastradosMais15DiasMetaAppService.GetAllAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<ItensCadastradosMais15DiasMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _itensCadastradosMais15DiasMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
