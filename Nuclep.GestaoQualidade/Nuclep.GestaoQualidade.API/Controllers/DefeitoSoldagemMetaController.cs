using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefeitoSoldagemMetaController : ControllerBase
    {
        private readonly IDefeitoSoldagemMetaAppService _defeitoSoldagemMetaAppService;

        public DefeitoSoldagemMetaController(IDefeitoSoldagemMetaAppService defeitoSoldagemMetaAppService)
        {
            _defeitoSoldagemMetaAppService = defeitoSoldagemMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(DefeitoSoldagemMetaResponseDTO), 201)]
        public async Task<IActionResult> AddAsync([FromBody] DefeitoSoldagemMetaRequestDTO request)
        {
            var response = await _defeitoSoldagemMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DefeitoSoldagemMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] DefeitoSoldagemMetaRequestDTO request)
        {
            var response = await _defeitoSoldagemMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DefeitoSoldagemMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _defeitoSoldagemMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(DefeitoSoldagemMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _defeitoSoldagemMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<DefeitoSoldagemMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _defeitoSoldagemMetaAppService.GetAllAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<DefeitoSoldagemMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _defeitoSoldagemMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
