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
    public class OcupacaoMaoObraController : ControllerBase
    {
        private readonly IOcupacaoMaoObraAppService _ocupacaoMaoObraAppService;
        private readonly IOcupacaoMaoObraMetaDomainService _ocupacaoMaoObraMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public OcupacaoMaoObraController(
            IOcupacaoMaoObraAppService ocupacaoMaoObraAppService,
            IOcupacaoMaoObraMetaDomainService ocupacaoMaoObraMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _ocupacaoMaoObraAppService = ocupacaoMaoObraAppService;
            _ocupacaoMaoObraMetaDomainService = ocupacaoMaoObraMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }




        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _ocupacaoMaoObraMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(OcupacaoMaoObraResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntas()
        {
           await _ocupacaoMaoObraAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OcupacaoMaoObraResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] OcupacaoMaoObraRequestDTO request)
        {
            var response = await _ocupacaoMaoObraAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(OcupacaoMaoObraResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _ocupacaoMaoObraAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(OcupacaoMaoObraResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _ocupacaoMaoObraAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<OcupacaoMaoObraResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _ocupacaoMaoObraAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<OcupacaoMaoObraResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _ocupacaoMaoObraAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<OcupacaoMaoObraResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _ocupacaoMaoObraAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
