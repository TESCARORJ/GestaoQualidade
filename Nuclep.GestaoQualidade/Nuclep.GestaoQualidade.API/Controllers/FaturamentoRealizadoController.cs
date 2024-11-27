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
    public class FaturamentoRealizadoController : ControllerBase
    {
        private readonly IFaturamentoRealizadoAppService _faturamentoRealizadoAppService;
        private readonly IFaturamentoRealizadoMetaDomainService _faturamentoRealizadoMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public FaturamentoRealizadoController(
            IFaturamentoRealizadoAppService faturamentoRealizadoAppService,
            IFaturamentoRealizadoMetaDomainService faturamentoRealizadoMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _faturamentoRealizadoAppService = faturamentoRealizadoAppService;
            _faturamentoRealizadoMetaDomainService = faturamentoRealizadoMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("IndicadorHabilitado")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> IndicadorHabilitado(string login)
        {
            var isExisteMeta = await _usuarioRepository.GetOneAsync(x => x.NomeAD == login);

            if (isExisteMeta.IsFaturamentoRealizado)
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
            var isExisteMeta = _faturamentoRealizadoMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }


        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(FaturamentoRealizadoResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntasAsync()
        {
            await _faturamentoRealizadoAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(FaturamentoRealizadoResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] FaturamentoRealizadoRequestDTO request)
        {
            var response = await _faturamentoRealizadoAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FaturamentoRealizadoResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _faturamentoRealizadoAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(FaturamentoRealizadoResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _faturamentoRealizadoAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<FaturamentoRealizadoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _faturamentoRealizadoAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<FaturamentoRealizadoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _faturamentoRealizadoAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<FaturamentoRealizadoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _faturamentoRealizadoAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
