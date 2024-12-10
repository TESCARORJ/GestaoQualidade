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
    public class RespostaAreasRiscosPrazoOriginalController : ControllerBase
    {
        private readonly IRespostaAreasRiscosPrazoOriginalAppService _respostaAreasRiscosPrazoOriginalAppService;
        private readonly IRespostaAreasRiscosPrazoOriginalMetaDomainService _respostaAreasRiscosPrazoOriginalMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public RespostaAreasRiscosPrazoOriginalController(
            IRespostaAreasRiscosPrazoOriginalAppService respostaAreasRiscosPrazoOriginalAppService,
            IRespostaAreasRiscosPrazoOriginalMetaDomainService respostaAreasRiscosPrazoOriginalMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _respostaAreasRiscosPrazoOriginalAppService = respostaAreasRiscosPrazoOriginalAppService;
            _respostaAreasRiscosPrazoOriginalMetaDomainService = respostaAreasRiscosPrazoOriginalMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("IndicadorHabilitado")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> IndicadorHabilitado(string login)
        {
            var isExisteMeta = await _usuarioRepository.GetOneAsync(x => x.NomeAD == login);

            if (isExisteMeta.IsRespostaAreasRiscosPrazoOriginal)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _respostaAreasRiscosPrazoOriginalMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }


        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(RespostaAreasRiscosPrazoOriginalResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntasAsync()
        {
            await _respostaAreasRiscosPrazoOriginalAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RespostaAreasRiscosPrazoOriginalResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] RespostaAreasRiscosPrazoOriginalRequestDTO request)
        {
            var response = await _respostaAreasRiscosPrazoOriginalAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RespostaAreasRiscosPrazoOriginalResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _respostaAreasRiscosPrazoOriginalAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(RespostaAreasRiscosPrazoOriginalResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _respostaAreasRiscosPrazoOriginalAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<RespostaAreasRiscosPrazoOriginalResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _respostaAreasRiscosPrazoOriginalAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<RespostaAreasRiscosPrazoOriginalResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _respostaAreasRiscosPrazoOriginalAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<RespostaAreasRiscosPrazoOriginalResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _respostaAreasRiscosPrazoOriginalAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
