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
    public class DefeitoSoldagemController : ControllerBase
    {
        private readonly IDefeitoSoldagemAppService _defeitoSoldagemAppService;
        private readonly IDefeitoSoldagemMetaDomainService _defeitoSoldagemMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public DefeitoSoldagemController(
            IDefeitoSoldagemAppService defeitoSoldagemAppService,
            IDefeitoSoldagemMetaDomainService defeitoSoldagemMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _defeitoSoldagemAppService = defeitoSoldagemAppService;
            _defeitoSoldagemMetaDomainService = defeitoSoldagemMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }

        //[HttpGet]
        //[Route("IsLocalidadeItaguaiHabilitado")]
        //[ProducesResponseType(typeof(bool), 201)]
        //public async Task<IActionResult> IsLocalidadeItaguaiHabilitado(string login)
        //{
        //    var isExisteMeta = await _usuarioRepository.GetOneAsync(x => x.NomeAD == login);

        //    if (isExisteMeta.IsLocalidadeItaguai)
        //    {
        //        return Ok(isExisteMeta);
        //    }

        //    return NotFound();


        //}

        //[HttpGet]
        //[Route("IsLocalidadeAramarHabilitado")]
        //[ProducesResponseType(typeof(bool), 201)]
        //public async Task<IActionResult> IsLocalidadeAramarHabilitado(string login)
        //{
        //    var isExisteMeta = _usuarioRepository.GetOneAsync(x => x.NomeAD == login).Result;

        //    if (isExisteMeta.IsLocalidadeAramar)
        //    {
        //        return Ok(isExisteMeta);
        //    }

        //    return NotFound();


        //}

        //[HttpGet]
        //[Route("IsCondensadorHabilitado")]
        //[ProducesResponseType(typeof(bool), 201)]
        //public async Task<IActionResult> IsCondensadorHabilitado(string login)
        //{
        //    var isExisteMeta = _usuarioRepository.GetOneAsync(x => x.NomeAD == login).Result;

        //    if (isExisteMeta.IsCondensador)
        //    {
        //        return Ok(isExisteMeta);
        //    }

        //    return NotFound();


        //}

        //[HttpGet]
        //[Route("IsVPRHabilitado")]
        //[ProducesResponseType(typeof(bool), 201)]
        //public async Task<IActionResult> IsVPRHabilitado(string login)
        //{
        //    var isExisteMeta = _usuarioRepository.GetOneAsync(x => x.NomeAD == login).Result;

        //    if (isExisteMeta.IsVPR)
        //    {
        //        return Ok(isExisteMeta);
        //    }

        //    return NotFound();


        //}



        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _defeitoSoldagemMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(DefeitoSoldagemResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntas()
        {
           await _defeitoSoldagemAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DefeitoSoldagemResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] DefeitoSoldagemRequestDTO request)
        {
            var response = await _defeitoSoldagemAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DefeitoSoldagemResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _defeitoSoldagemAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(DefeitoSoldagemResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _defeitoSoldagemAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<DefeitoSoldagemResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _defeitoSoldagemAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<DefeitoSoldagemResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _defeitoSoldagemAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<DefeitoSoldagemResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _defeitoSoldagemAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
