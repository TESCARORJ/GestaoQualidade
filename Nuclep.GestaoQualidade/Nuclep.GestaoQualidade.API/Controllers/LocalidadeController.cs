using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Domain.Enumeradores;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadeController : ControllerBase
    {
        private readonly ILocalidadeAppService _localidadeAppService;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public LocalidadeController(ILocalidadeAppService localidadeAppService, IHttpContextAccessor httpContextAccessor)
        {
            _localidadeAppService = localidadeAppService;
            _httpContextAccessor = httpContextAccessor;
        }
       
        [HttpPost]
        [ProducesResponseType(typeof(LocalidadeResponseDTO), 201)]
        public async Task<IActionResult> AddAsync([FromBody] LocalidadeRequestDTO request)
        {
            var response = await _localidadeAppService.AddAsync(request);

            return StatusCode(201, response);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LocalidadeResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] LocalidadeRequestDTO request)
        {
            var response = await _localidadeAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(LocalidadeResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _localidadeAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(LocalidadeResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _localidadeAppService.GetByIdAsync(id);

            if (response == null)
            {
                return NotFound("Usuário não existe ou não foi encontrado");
            }

            return Ok(response);
        }

        [HttpGet("nome/{nome}")]
        [ProducesResponseType(typeof(LocalidadeResponseDTO), 200)]
        public async Task<IActionResult> GetByNameListAsync(string nome)
        {
            var response = await _localidadeAppService.GetByNameListAsync(nome);

            if (response == null)
            {
                return NotFound("Usuário não existe ou não foi encontrado");
            }

            return Ok(response);
        }




        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<LocalidadeResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {       
            var response = await _localidadeAppService.GetAllAsync();


            if (response == null)
            {
                return NotFound("Nenhum usuário localizado");
            }


            return Ok(response);
        }








    }
}
