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
    public class SatisfacaoClientesController : ControllerBase
    {
        private readonly ISatisfacaoClientesAppService _satisfacaoClientesAppService;
        private readonly ISatisfacaoClientesMetaDomainService _satisfacaoClientesMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public SatisfacaoClientesController(
            ISatisfacaoClientesAppService satisfacaoClientesAppService,
            ISatisfacaoClientesMetaDomainService satisfacaoClientesMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _satisfacaoClientesAppService = satisfacaoClientesAppService;
            _satisfacaoClientesMetaDomainService = satisfacaoClientesMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }




        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _satisfacaoClientesMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(SatisfacaoClientesResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntas()
        {
           await _satisfacaoClientesAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(SatisfacaoClientesResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] SatisfacaoClientesRequestDTO request)
        {
            var response = await _satisfacaoClientesAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(SatisfacaoClientesResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _satisfacaoClientesAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(SatisfacaoClientesResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _satisfacaoClientesAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<SatisfacaoClientesResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _satisfacaoClientesAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<SatisfacaoClientesResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _satisfacaoClientesAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<SatisfacaoClientesResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _satisfacaoClientesAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
