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
    public class NaoConformidadeController : ControllerBase
    {
        private readonly INaoConformidadeAppService _naoConformidadeAppService;
        private readonly INaoConformidadeMetaDomainService _naoConformidadeMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public NaoConformidadeController(
            INaoConformidadeAppService naoConformidadeAppService,
            INaoConformidadeMetaDomainService naoConformidadeMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _naoConformidadeAppService = naoConformidadeAppService;
            _naoConformidadeMetaDomainService = naoConformidadeMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }




        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _naoConformidadeMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(NaoConformidadeResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntas()
        {
           await _naoConformidadeAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(NaoConformidadeResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] NaoConformidadeRequestDTO request)
        {
            var response = await _naoConformidadeAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(NaoConformidadeResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _naoConformidadeAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(NaoConformidadeResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _naoConformidadeAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<NaoConformidadeResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _naoConformidadeAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<NaoConformidadeResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _naoConformidadeAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<NaoConformidadeResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _naoConformidadeAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
