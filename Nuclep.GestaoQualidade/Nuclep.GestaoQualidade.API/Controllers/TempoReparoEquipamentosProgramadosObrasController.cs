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
    public class TempoReparoEquipamentosProgramadosObrasController : ControllerBase
    {
        private readonly ITempoReparoEquipamentosProgramadosObrasAppService _tempoReparoEquipamentosProgramadosObrasAppService;
        private readonly ITempoReparoEquipamentosProgramadosObrasMetaDomainService _tempoReparoEquipamentosProgramadosObrasMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public TempoReparoEquipamentosProgramadosObrasController(
            ITempoReparoEquipamentosProgramadosObrasAppService tempoReparoEquipamentosProgramadosObrasAppService,
            ITempoReparoEquipamentosProgramadosObrasMetaDomainService tempoReparoEquipamentosProgramadosObrasMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _tempoReparoEquipamentosProgramadosObrasAppService = tempoReparoEquipamentosProgramadosObrasAppService;
            _tempoReparoEquipamentosProgramadosObrasMetaDomainService = tempoReparoEquipamentosProgramadosObrasMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }




        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _tempoReparoEquipamentosProgramadosObrasMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(TempoReparoEquipamentosProgramadosObrasResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntas()
        {
           await _tempoReparoEquipamentosProgramadosObrasAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TempoReparoEquipamentosProgramadosObrasResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] TempoReparoEquipamentosProgramadosObrasRequestDTO request)
        {
            var response = await _tempoReparoEquipamentosProgramadosObrasAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TempoReparoEquipamentosProgramadosObrasResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _tempoReparoEquipamentosProgramadosObrasAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(TempoReparoEquipamentosProgramadosObrasResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _tempoReparoEquipamentosProgramadosObrasAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<TempoReparoEquipamentosProgramadosObrasResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _tempoReparoEquipamentosProgramadosObrasAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<TempoReparoEquipamentosProgramadosObrasResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _tempoReparoEquipamentosProgramadosObrasAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<TempoReparoEquipamentosProgramadosObrasResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _tempoReparoEquipamentosProgramadosObrasAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
