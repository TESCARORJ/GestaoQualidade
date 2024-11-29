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
    public class ProdutividadeMaoObraController : ControllerBase
    {
        private readonly IProdutividadeMaoObraAppService _produtividadeMaoObraAppService;
        private readonly IProdutividadeMaoObraMetaDomainService _produtividadeMaoObraMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public ProdutividadeMaoObraController(
            IProdutividadeMaoObraAppService produtividadeMaoObraAppService,
            IProdutividadeMaoObraMetaDomainService produtividadeMaoObraMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _produtividadeMaoObraAppService = produtividadeMaoObraAppService;
            _produtividadeMaoObraMetaDomainService = produtividadeMaoObraMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }




        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _produtividadeMaoObraMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(ProdutividadeMaoObraResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntas()
        {
           await _produtividadeMaoObraAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProdutividadeMaoObraResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] ProdutividadeMaoObraRequestDTO request)
        {
            var response = await _produtividadeMaoObraAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutividadeMaoObraResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _produtividadeMaoObraAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(ProdutividadeMaoObraResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _produtividadeMaoObraAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<ProdutividadeMaoObraResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _produtividadeMaoObraAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<ProdutividadeMaoObraResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _produtividadeMaoObraAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<ProdutividadeMaoObraResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _produtividadeMaoObraAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
