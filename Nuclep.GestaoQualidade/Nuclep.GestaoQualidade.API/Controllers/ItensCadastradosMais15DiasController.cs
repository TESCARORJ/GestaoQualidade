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
    public class ItensCadastradosMais15DiasController : ControllerBase
    {
        private readonly IItensCadastradosMais15DiasAppService _itensCadastradosMais15DiasAppService;
        private readonly IItensCadastradosMais15DiasMetaDomainService _itensCadastradosMais15DiasMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public ItensCadastradosMais15DiasController(
            IItensCadastradosMais15DiasAppService itensCadastradosMais15DiasAppService,
            IItensCadastradosMais15DiasMetaDomainService itensCadastradosMais15DiasMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _itensCadastradosMais15DiasAppService = itensCadastradosMais15DiasAppService;
            _itensCadastradosMais15DiasMetaDomainService = itensCadastradosMais15DiasMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }




        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _itensCadastradosMais15DiasMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(ItensCadastradosMais15DiasResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntas()
        {
           await _itensCadastradosMais15DiasAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ItensCadastradosMais15DiasResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] ItensCadastradosMais15DiasRequestDTO request)
        {
            var response = await _itensCadastradosMais15DiasAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ItensCadastradosMais15DiasResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _itensCadastradosMais15DiasAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(ItensCadastradosMais15DiasResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _itensCadastradosMais15DiasAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<ItensCadastradosMais15DiasResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _itensCadastradosMais15DiasAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<ItensCadastradosMais15DiasResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _itensCadastradosMais15DiasAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<ItensCadastradosMais15DiasResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _itensCadastradosMais15DiasAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
