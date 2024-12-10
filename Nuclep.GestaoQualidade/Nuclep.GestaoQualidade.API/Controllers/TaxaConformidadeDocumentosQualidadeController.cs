using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Application.Interfaces.Sistema;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaConformidadeDocumentosQualidadeController : ControllerBase
    {
        private readonly ITaxaConformidadeDocumentosQualidadeAppService _taxaConformidadeDocumentosQualidadeAppService;
        private readonly ITaxaConformidadeDocumentosQualidadeMetaDomainService _taxaConformidadeDocumentosQualidadeMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public TaxaConformidadeDocumentosQualidadeController(
            ITaxaConformidadeDocumentosQualidadeAppService taxaConformidadeDocumentosQualidadeAppService,
            ITaxaConformidadeDocumentosQualidadeMetaDomainService taxaConformidadeDocumentosQualidadeMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _taxaConformidadeDocumentosQualidadeAppService = taxaConformidadeDocumentosQualidadeAppService;
            _taxaConformidadeDocumentosQualidadeMetaDomainService = taxaConformidadeDocumentosQualidadeMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("IndicadorHabilitado")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> IndicadorHabilitado(string login)
        {
            try
            {
                var isExisteMeta = await _usuarioRepository.GetOneAsync(x => x.NomeAD == login);

                if (isExisteMeta.IsTaxaConformidadeDocumentosQualidade)
                {
                    return Ok(isExisteMeta);
                }

                return NotFound();
            }
            catch (Exception ex)
            {

                throw;
            }
           


        }

        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _taxaConformidadeDocumentosQualidadeMetaDomainService.GetAllAsync().Result.Select(x => x.Ano1 & x.Ano2).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }


        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(TaxaConformidadeDocumentosQualidadeResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntasAsync()
        {
            await _taxaConformidadeDocumentosQualidadeAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TaxaConformidadeDocumentosQualidadeResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] TaxaConformidadeDocumentosQualidadeRequestDTO request)
        {
            var response = await _taxaConformidadeDocumentosQualidadeAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TaxaConformidadeDocumentosQualidadeResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _taxaConformidadeDocumentosQualidadeAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(TaxaConformidadeDocumentosQualidadeResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _taxaConformidadeDocumentosQualidadeAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<TaxaConformidadeDocumentosQualidadeResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _taxaConformidadeDocumentosQualidadeAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<TaxaConformidadeDocumentosQualidadeResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _taxaConformidadeDocumentosQualidadeAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<TaxaConformidadeDocumentosQualidadeResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _taxaConformidadeDocumentosQualidadeAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
