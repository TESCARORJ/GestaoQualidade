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
    public class EficaciaTreinamentoController : ControllerBase
    {
        private readonly IEficaciaTreinamentoAppService _eficaciaTreinamentoAppService;
        private readonly IEficaciaTreinamentoMetaDomainService _eficaciaTreinamentoMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public EficaciaTreinamentoController(
            IEficaciaTreinamentoAppService eficaciaTreinamentoAppService,
            IEficaciaTreinamentoMetaDomainService eficaciaTreinamentoMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _eficaciaTreinamentoAppService = eficaciaTreinamentoAppService;
            _eficaciaTreinamentoMetaDomainService = eficaciaTreinamentoMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("IndicadorHabilitado")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> IndicadorHabilitado(string login)
        {
            var isExisteMeta = await _usuarioRepository.GetOneAsync(x => x.NomeAD == login);

            if (isExisteMeta.IsEficaciaTreinamento)
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
            var isExisteMeta = _eficaciaTreinamentoMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(EficaciaTreinamentoResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntasAsync()
        {
            await _eficaciaTreinamentoAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EficaciaTreinamentoResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] EficaciaTreinamentoRequestDTO request)
        {
            var response = await _eficaciaTreinamentoAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EficaciaTreinamentoResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _eficaciaTreinamentoAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(EficaciaTreinamentoResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _eficaciaTreinamentoAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<EficaciaTreinamentoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _eficaciaTreinamentoAppService.GetAllAsync();

            return Ok(response);
        }

          [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<EficaciaTreinamentoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _eficaciaTreinamentoAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<EficaciaTreinamentoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _eficaciaTreinamentoAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
