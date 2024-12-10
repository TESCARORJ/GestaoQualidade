using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaConformidadeDocumentosQualidadeMetaController : ControllerBase
    {
        private readonly ITaxaConformidadeDocumentosQualidadeMetaAppService _taxaConformidadeDocumentosQualidadeMetaAppService;

        public TaxaConformidadeDocumentosQualidadeMetaController(ITaxaConformidadeDocumentosQualidadeMetaAppService taxaConformidadeDocumentosQualidadeMetaAppService)
        {
            _taxaConformidadeDocumentosQualidadeMetaAppService = taxaConformidadeDocumentosQualidadeMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaxaConformidadeDocumentosQualidadeMetaResponseDTO),201)]
        public async Task<IActionResult> AddAsync([FromBody] TaxaConformidadeDocumentosQualidadeMetaRequestDTO request)
        {
            var response = await _taxaConformidadeDocumentosQualidadeMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TaxaConformidadeDocumentosQualidadeMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] TaxaConformidadeDocumentosQualidadeMetaRequestDTO request)
        {
            var response = await _taxaConformidadeDocumentosQualidadeMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TaxaConformidadeDocumentosQualidadeMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _taxaConformidadeDocumentosQualidadeMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(TaxaConformidadeDocumentosQualidadeMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _taxaConformidadeDocumentosQualidadeMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<TaxaConformidadeDocumentosQualidadeMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _taxaConformidadeDocumentosQualidadeMetaAppService.GetAllAsync();

            return Ok(response);
        }

        
        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<TaxaConformidadeDocumentosQualidadeMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _taxaConformidadeDocumentosQualidadeMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
