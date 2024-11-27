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
    public class AderenciaProgramacaoMensalController : ControllerBase
    {
        private readonly IAderenciaProgramacaoMensalAppService _aderenciaProgramacaoMensalAppService;
        private readonly IAderenciaProgramacaoMensalMetaDomainService _aderenciaProgramacaoMensalMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public AderenciaProgramacaoMensalController(
            IAderenciaProgramacaoMensalAppService aderenciaProgramacaoMensalAppService,
            IAderenciaProgramacaoMensalMetaDomainService aderenciaProgramacaoMensalMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _aderenciaProgramacaoMensalAppService = aderenciaProgramacaoMensalAppService;
            _aderenciaProgramacaoMensalMetaDomainService = aderenciaProgramacaoMensalMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("IndicadorHabilitado")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> IndicadorHabilitado(string login)
        {
            var isExisteMeta = await _usuarioRepository.GetOneAsync(x => x.NomeAD == login);

            if (isExisteMeta.IsAderenciaProgramacaoMensal)
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
            var isExisteMeta = _aderenciaProgramacaoMensalMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(AderenciaProgramacaoMensalResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntasAsync()
        {
            await _aderenciaProgramacaoMensalAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AderenciaProgramacaoMensalResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] AderenciaProgramacaoMensalRequestDTO request)
        {
            var response = await _aderenciaProgramacaoMensalAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AderenciaProgramacaoMensalResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _aderenciaProgramacaoMensalAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(AderenciaProgramacaoMensalResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _aderenciaProgramacaoMensalAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<AderenciaProgramacaoMensalResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _aderenciaProgramacaoMensalAppService.GetAllAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<AderenciaProgramacaoMensalResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _aderenciaProgramacaoMensalAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
