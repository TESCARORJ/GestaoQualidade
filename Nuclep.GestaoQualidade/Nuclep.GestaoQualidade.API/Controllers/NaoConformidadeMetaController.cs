using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NaoConformidadeMetaController : ControllerBase
    {
        private readonly INaoConformidadeMetaAppService _naoConformidadeMetaAppService;

        public NaoConformidadeMetaController(INaoConformidadeMetaAppService naoConformidadeMetaAppService)
        {
            _naoConformidadeMetaAppService = naoConformidadeMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(NaoConformidadeMetaResponseDTO), 201)]
        public async Task<IActionResult> AddAsync([FromBody] NaoConformidadeMetaRequestDTO request)
        {
            var response = await _naoConformidadeMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(NaoConformidadeMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] NaoConformidadeMetaRequestDTO request)
        {
            var response = await _naoConformidadeMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(NaoConformidadeMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _naoConformidadeMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(NaoConformidadeMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _naoConformidadeMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<NaoConformidadeMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _naoConformidadeMetaAppService.GetAllAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<NaoConformidadeMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _naoConformidadeMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
