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
    public class AcaoCorrecaoAvaliadaEficazController : ControllerBase
    {
        private readonly IAcaoCorrecaoAvaliadaEficazAppService _acaoCorrecaoAvaliadaEficazAppService;
        private readonly IAcaoCorrecaoAvaliadaEficazMetaDomainService _acaoCorrecaoAvaliadaEficazMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public AcaoCorrecaoAvaliadaEficazController(
            IAcaoCorrecaoAvaliadaEficazAppService acaoCorrecaoAvaliadaEficazAppService,
            IAcaoCorrecaoAvaliadaEficazMetaDomainService acaoCorrecaoAvaliadaEficazMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _acaoCorrecaoAvaliadaEficazAppService = acaoCorrecaoAvaliadaEficazAppService;
            _acaoCorrecaoAvaliadaEficazMetaDomainService = acaoCorrecaoAvaliadaEficazMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("IndicadorHabilitado")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> IndicadorHabilitado(string login)
        {
            var isExisteMeta = await _usuarioRepository.GetOneAsync(x => x.NomeAD == login);

            if (isExisteMeta.IsAcaoCorrecaoAvaliadaEficaz)
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
            var isExisteMeta = _acaoCorrecaoAvaliadaEficazMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(AcaoCorrecaoAvaliadaEficazResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntasAsync()
        {
            await _acaoCorrecaoAvaliadaEficazAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AcaoCorrecaoAvaliadaEficazResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] AcaoCorrecaoAvaliadaEficazRequestDTO request)
        {
            var response = await _acaoCorrecaoAvaliadaEficazAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AcaoCorrecaoAvaliadaEficazResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _acaoCorrecaoAvaliadaEficazAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(AcaoCorrecaoAvaliadaEficazResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _acaoCorrecaoAvaliadaEficazAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<AcaoCorrecaoAvaliadaEficazResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _acaoCorrecaoAvaliadaEficazAppService.GetAllAsync();

            return Ok(response);
        }
         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<AcaoCorrecaoAvaliadaEficazResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _acaoCorrecaoAvaliadaEficazAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<AcaoCorrecaoAvaliadaEficazResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _acaoCorrecaoAvaliadaEficazAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
