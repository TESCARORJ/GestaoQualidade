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
    public class TempoMedioSolucaoController : ControllerBase
    {
        private readonly ITempoMedioSolucaoAppService _tempoMedioSolucaoAppService;
        private readonly ITempoMedioSolucaoMetaDomainService _tempoMedioSolucaoMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public TempoMedioSolucaoController(
            ITempoMedioSolucaoAppService tempoMedioSolucaoAppService,
            ITempoMedioSolucaoMetaDomainService tempoMedioSolucaoMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _tempoMedioSolucaoAppService = tempoMedioSolucaoAppService;
            _tempoMedioSolucaoMetaDomainService = tempoMedioSolucaoMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }




        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _tempoMedioSolucaoMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(TempoMedioSolucaoResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntas()
        {
           await _tempoMedioSolucaoAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TempoMedioSolucaoResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] TempoMedioSolucaoRequestDTO request)
        {
            var response = await _tempoMedioSolucaoAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TempoMedioSolucaoResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _tempoMedioSolucaoAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(TempoMedioSolucaoResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _tempoMedioSolucaoAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<TempoMedioSolucaoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _tempoMedioSolucaoAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<TempoMedioSolucaoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _tempoMedioSolucaoAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<TempoMedioSolucaoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _tempoMedioSolucaoAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
