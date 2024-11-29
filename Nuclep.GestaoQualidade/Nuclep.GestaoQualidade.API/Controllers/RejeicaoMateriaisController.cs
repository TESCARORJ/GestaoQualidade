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
    public class RejeicaoMateriaisController : ControllerBase
    {
        private readonly IRejeicaoMateriaisAppService _rejeicaoMateriaisAppService;
        private readonly IRejeicaoMateriaisMetaDomainService _rejeicaoMateriaisMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public RejeicaoMateriaisController(
            IRejeicaoMateriaisAppService rejeicaoMateriaisAppService,
            IRejeicaoMateriaisMetaDomainService rejeicaoMateriaisMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _rejeicaoMateriaisAppService = rejeicaoMateriaisAppService;
            _rejeicaoMateriaisMetaDomainService = rejeicaoMateriaisMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("IndicadorHabilitado")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> IndicadorHabilitado(string login)
        {
            var isExisteMeta = await _usuarioRepository.GetOneAsync(x => x.NomeAD == login);

            if (isExisteMeta.IsRejeicaoMateriais)
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
            var isExisteMeta = _rejeicaoMateriaisMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }


        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(RejeicaoMateriaisResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntasAsync()
        {
            await _rejeicaoMateriaisAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RejeicaoMateriaisResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] RejeicaoMateriaisRequestDTO request)
        {
            var response = await _rejeicaoMateriaisAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RejeicaoMateriaisResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _rejeicaoMateriaisAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(RejeicaoMateriaisResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _rejeicaoMateriaisAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<RejeicaoMateriaisResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _rejeicaoMateriaisAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<RejeicaoMateriaisResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _rejeicaoMateriaisAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<RejeicaoMateriaisResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _rejeicaoMateriaisAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
