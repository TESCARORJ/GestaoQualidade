using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempoReparoEquipamentosProgramadosObrasMetaController : ControllerBase
    {
        private readonly ITempoReparoEquipamentosProgramadosObrasMetaAppService _tempoReparoEquipamentosProgramadosObrasMetaAppService;

        public TempoReparoEquipamentosProgramadosObrasMetaController(ITempoReparoEquipamentosProgramadosObrasMetaAppService tempoReparoEquipamentosProgramadosObrasMetaAppService)
        {
            _tempoReparoEquipamentosProgramadosObrasMetaAppService = tempoReparoEquipamentosProgramadosObrasMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TempoReparoEquipamentosProgramadosObrasMetaResponseDTO), 201)]
        public async Task<IActionResult> AddAsync([FromBody] TempoReparoEquipamentosProgramadosObrasMetaRequestDTO request)
        {
            var response = await _tempoReparoEquipamentosProgramadosObrasMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TempoReparoEquipamentosProgramadosObrasMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] TempoReparoEquipamentosProgramadosObrasMetaRequestDTO request)
        {
            var response = await _tempoReparoEquipamentosProgramadosObrasMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TempoReparoEquipamentosProgramadosObrasMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _tempoReparoEquipamentosProgramadosObrasMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(TempoReparoEquipamentosProgramadosObrasMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _tempoReparoEquipamentosProgramadosObrasMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<TempoReparoEquipamentosProgramadosObrasMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _tempoReparoEquipamentosProgramadosObrasMetaAppService.GetAllAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<TempoReparoEquipamentosProgramadosObrasMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _tempoReparoEquipamentosProgramadosObrasMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
