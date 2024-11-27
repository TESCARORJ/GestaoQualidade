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
    public class AutoavaliacaoGerencialSGQController : ControllerBase
    {
        private readonly IAutoavaliacaoGerencialSGQAppService _autoavaliacaoGerencialSGQAppService;
        private readonly IAutoavaliacaoGerencialSGQMetaDomainService _autoavaliacaoGerencialSGQMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public AutoavaliacaoGerencialSGQController(
            IAutoavaliacaoGerencialSGQAppService autoavaliacaoGerencialSGQAppService,
            IAutoavaliacaoGerencialSGQMetaDomainService autoavaliacaoGerencialSGQMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _autoavaliacaoGerencialSGQAppService = autoavaliacaoGerencialSGQAppService;
            _autoavaliacaoGerencialSGQMetaDomainService = autoavaliacaoGerencialSGQMetaDomainService;
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

                if (isExisteMeta.IsAutoavaliacaoGerencialSGQ)
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
            var isExisteMeta = _autoavaliacaoGerencialSGQMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }


        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(AutoavaliacaoGerencialSGQResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntasAsync()
        {
            await _autoavaliacaoGerencialSGQAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AutoavaliacaoGerencialSGQResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] AutoavaliacaoGerencialSGQRequestDTO request)
        {
            var response = await _autoavaliacaoGerencialSGQAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AutoavaliacaoGerencialSGQResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _autoavaliacaoGerencialSGQAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(AutoavaliacaoGerencialSGQResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _autoavaliacaoGerencialSGQAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<AutoavaliacaoGerencialSGQResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _autoavaliacaoGerencialSGQAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<AutoavaliacaoGerencialSGQResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _autoavaliacaoGerencialSGQAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<AutoavaliacaoGerencialSGQResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _autoavaliacaoGerencialSGQAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
