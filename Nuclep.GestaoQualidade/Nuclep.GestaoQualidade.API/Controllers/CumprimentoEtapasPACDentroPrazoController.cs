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
    public class CumprimentoEtapasPACDentroPrazoController : ControllerBase
    {
        private readonly ICumprimentoEtapasPACDentroPrazoAppService _cumprimentoEtapasPACDentroPrazoAppService;
        private readonly ICumprimentoEtapasPACDentroPrazoMetaDomainService _cumprimentoEtapasPACDentroPrazoMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public CumprimentoEtapasPACDentroPrazoController(
            ICumprimentoEtapasPACDentroPrazoAppService cumprimentoEtapasPACDentroPrazoAppService,
            ICumprimentoEtapasPACDentroPrazoMetaDomainService cumprimentoEtapasPACDentroPrazoMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _cumprimentoEtapasPACDentroPrazoAppService = cumprimentoEtapasPACDentroPrazoAppService;
            _cumprimentoEtapasPACDentroPrazoMetaDomainService = cumprimentoEtapasPACDentroPrazoMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("IndicadorHabilitado")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> IndicadorHabilitado(string login)
        {
            var isExisteMeta = await _usuarioRepository.GetOneAsync(x => x.NomeAD == login);

            if (isExisteMeta.IsCumprimentoEtapasPACDentroPrazo)
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
            var isExisteMeta = _cumprimentoEtapasPACDentroPrazoMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(CumprimentoEtapasPACDentroPrazoResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntasAsync()
        {
            await _cumprimentoEtapasPACDentroPrazoAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CumprimentoEtapasPACDentroPrazoResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] CumprimentoEtapasPACDentroPrazoRequestDTO request)
        {
            var response = await _cumprimentoEtapasPACDentroPrazoAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CumprimentoEtapasPACDentroPrazoResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _cumprimentoEtapasPACDentroPrazoAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(CumprimentoEtapasPACDentroPrazoResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _cumprimentoEtapasPACDentroPrazoAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<CumprimentoEtapasPACDentroPrazoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _cumprimentoEtapasPACDentroPrazoAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<CumprimentoEtapasPACDentroPrazoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _cumprimentoEtapasPACDentroPrazoAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<CumprimentoEtapasPACDentroPrazoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _cumprimentoEtapasPACDentroPrazoAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
