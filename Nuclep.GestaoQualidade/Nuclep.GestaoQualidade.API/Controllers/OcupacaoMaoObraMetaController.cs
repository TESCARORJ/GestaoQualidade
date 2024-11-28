using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcupacaoMaoObraMetaController : ControllerBase
    {
        private readonly IOcupacaoMaoObraMetaAppService _ocupacaoMaoObraMetaAppService;

        public OcupacaoMaoObraMetaController(IOcupacaoMaoObraMetaAppService ocupacaoMaoObraMetaAppService)
        {
            _ocupacaoMaoObraMetaAppService = ocupacaoMaoObraMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OcupacaoMaoObraMetaResponseDTO), 201)]
        public async Task<IActionResult> AddAsync([FromBody] OcupacaoMaoObraMetaRequestDTO request)
        {
            var response = await _ocupacaoMaoObraMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OcupacaoMaoObraMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] OcupacaoMaoObraMetaRequestDTO request)
        {
            var response = await _ocupacaoMaoObraMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(OcupacaoMaoObraMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _ocupacaoMaoObraMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(OcupacaoMaoObraMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _ocupacaoMaoObraMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<OcupacaoMaoObraMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _ocupacaoMaoObraMetaAppService.GetAllAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<OcupacaoMaoObraMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _ocupacaoMaoObraMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
