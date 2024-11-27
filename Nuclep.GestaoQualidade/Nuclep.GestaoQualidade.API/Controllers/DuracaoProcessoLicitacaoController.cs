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
    public class DuracaoProcessoLicitacaoController : ControllerBase
    {
        private readonly IDuracaoProcessoLicitacaoAppService _duracaoProcessoLicitacaoAppService;
        private readonly IDuracaoProcessoLicitacaoMetaDomainService _duracaoProcessoLicitacaoMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public DuracaoProcessoLicitacaoController(
            IDuracaoProcessoLicitacaoAppService duracaoProcessoLicitacaoAppService,
            IDuracaoProcessoLicitacaoMetaDomainService duracaoProcessoLicitacaoMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _duracaoProcessoLicitacaoAppService = duracaoProcessoLicitacaoAppService;
            _duracaoProcessoLicitacaoMetaDomainService = duracaoProcessoLicitacaoMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }

        

        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _duracaoProcessoLicitacaoMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }


        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(DuracaoProcessoLicitacaoResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntasAsync()
        {
            await _duracaoProcessoLicitacaoAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DuracaoProcessoLicitacaoResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] DuracaoProcessoLicitacaoRequestDTO request)
        {
            var response = await _duracaoProcessoLicitacaoAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DuracaoProcessoLicitacaoResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _duracaoProcessoLicitacaoAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(DuracaoProcessoLicitacaoResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _duracaoProcessoLicitacaoAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<DuracaoProcessoLicitacaoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _duracaoProcessoLicitacaoAppService.GetAllAsync();

            return Ok(response);
        }

          [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<DuracaoProcessoLicitacaoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _duracaoProcessoLicitacaoAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<DuracaoProcessoLicitacaoResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _duracaoProcessoLicitacaoAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
