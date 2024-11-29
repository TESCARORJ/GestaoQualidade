using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutividadeMaoObraMetaController : ControllerBase
    {
        private readonly IProdutividadeMaoObraMetaAppService _produtividadeMaoObraMetaAppService;

        public ProdutividadeMaoObraMetaController(IProdutividadeMaoObraMetaAppService produtividadeMaoObraMetaAppService)
        {
            _produtividadeMaoObraMetaAppService = produtividadeMaoObraMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProdutividadeMaoObraMetaResponseDTO), 201)]
        public async Task<IActionResult> AddAsync([FromBody] ProdutividadeMaoObraMetaRequestDTO request)
        {
            var response = await _produtividadeMaoObraMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProdutividadeMaoObraMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] ProdutividadeMaoObraMetaRequestDTO request)
        {
            var response = await _produtividadeMaoObraMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutividadeMaoObraMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _produtividadeMaoObraMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(ProdutividadeMaoObraMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _produtividadeMaoObraMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<ProdutividadeMaoObraMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _produtividadeMaoObraMetaAppService.GetAllAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<ProdutividadeMaoObraMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _produtividadeMaoObraMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
