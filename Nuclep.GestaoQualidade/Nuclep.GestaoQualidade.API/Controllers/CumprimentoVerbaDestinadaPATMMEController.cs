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
    public class CumprimentoVerbaDestinadaPATMMEController : ControllerBase
    {
        private readonly ICumprimentoVerbaDestinadaPATMMEAppService _cumprimentoVerbaDestinadaPATMMEAppService;
        private readonly ICumprimentoVerbaDestinadaPATMMEMetaDomainService _cumprimentoVerbaDestinadaPATMMEMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public CumprimentoVerbaDestinadaPATMMEController(
            ICumprimentoVerbaDestinadaPATMMEAppService cumprimentoVerbaDestinadaPATMMEAppService,
            ICumprimentoVerbaDestinadaPATMMEMetaDomainService cumprimentoVerbaDestinadaPATMMEMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _cumprimentoVerbaDestinadaPATMMEAppService = cumprimentoVerbaDestinadaPATMMEAppService;
            _cumprimentoVerbaDestinadaPATMMEMetaDomainService = cumprimentoVerbaDestinadaPATMMEMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("IndicadorHabilitado")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> IndicadorHabilitado(string login)
        {
            var isExisteMeta = await _usuarioRepository.GetOneAsync(x => x.NomeAD == login);

            if (isExisteMeta.IsCumprimentoVerbaDestinadaPATMME)
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
            var isExisteMeta = _cumprimentoVerbaDestinadaPATMMEMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(CumprimentoVerbaDestinadaPATMMEResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntasAsync()
        {
            await _cumprimentoVerbaDestinadaPATMMEAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CumprimentoVerbaDestinadaPATMMEResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] CumprimentoVerbaDestinadaPATMMERequestDTO request)
        {
            var response = await _cumprimentoVerbaDestinadaPATMMEAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CumprimentoVerbaDestinadaPATMMEResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _cumprimentoVerbaDestinadaPATMMEAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(CumprimentoVerbaDestinadaPATMMEResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _cumprimentoVerbaDestinadaPATMMEAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<CumprimentoVerbaDestinadaPATMMEResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _cumprimentoVerbaDestinadaPATMMEAppService.GetAllAsync();

            return Ok(response);
        }

          [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<CumprimentoVerbaDestinadaPATMMEResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _cumprimentoVerbaDestinadaPATMMEAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<CumprimentoVerbaDestinadaPATMMEResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _cumprimentoVerbaDestinadaPATMMEAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
