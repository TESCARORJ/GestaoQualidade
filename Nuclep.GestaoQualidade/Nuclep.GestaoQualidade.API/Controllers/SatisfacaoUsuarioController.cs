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
    public class SatisfacaoUsuarioController : ControllerBase
    {
        private readonly ISatisfacaoUsuarioAppService _satisfacaoUsuarioAppService;
        private readonly ISatisfacaoUsuarioMetaDomainService _satisfacaoUsuarioMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public SatisfacaoUsuarioController(
            ISatisfacaoUsuarioAppService satisfacaoUsuarioAppService,
            ISatisfacaoUsuarioMetaDomainService satisfacaoUsuarioMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _satisfacaoUsuarioAppService = satisfacaoUsuarioAppService;
            _satisfacaoUsuarioMetaDomainService = satisfacaoUsuarioMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }




        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _satisfacaoUsuarioMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(SatisfacaoUsuarioResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntas()
        {
           await _satisfacaoUsuarioAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SatisfacaoUsuarioResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] SatisfacaoUsuarioRequestDTO request)
        {
            var response = await _satisfacaoUsuarioAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SatisfacaoUsuarioResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _satisfacaoUsuarioAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(SatisfacaoUsuarioResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _satisfacaoUsuarioAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<SatisfacaoUsuarioResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _satisfacaoUsuarioAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<SatisfacaoUsuarioResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _satisfacaoUsuarioAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<SatisfacaoUsuarioResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _satisfacaoUsuarioAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
