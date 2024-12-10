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
    public class ServiceLevelAgreementController : ControllerBase
    {
        private readonly IServiceLevelAgreementAppService _serviceLevelAgreementAppService;
        private readonly IServiceLevelAgreementMetaDomainService _serviceLevelAgreementMetaDomainService;
        private readonly IUsuarioRepository _usuarioRepository;

        public ServiceLevelAgreementController(
            IServiceLevelAgreementAppService serviceLevelAgreementAppService,
            IServiceLevelAgreementMetaDomainService serviceLevelAgreementMetaDomainService,
            IUsuarioRepository usuarioRepository)
        {
            _serviceLevelAgreementAppService = serviceLevelAgreementAppService;
            _serviceLevelAgreementMetaDomainService = serviceLevelAgreementMetaDomainService;
            _usuarioRepository = usuarioRepository;
        }




        [HttpGet]
        [Route("VerificaMetaPerguntas")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> VerificaMetaPerguntas()
        {
            var isExisteMeta = _serviceLevelAgreementMetaDomainService.GetAllAsync().Result.Select(x => x.Ano).Any();

            if (isExisteMeta == true)
            {
                return Ok(isExisteMeta);
            }

            return NotFound();


        }

        //Gerar Perguntas
        [HttpGet]
        [Route("GararPerguntas")]
        [ProducesResponseType(typeof(ServiceLevelAgreementResponseDTO), 201)]
        public async Task<IActionResult> GararPerguntas()
        {
           await _serviceLevelAgreementAppService.GararPerguntasAsync();
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ServiceLevelAgreementResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] ServiceLevelAgreementRequestDTO request)
        {
            var response = await _serviceLevelAgreementAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ServiceLevelAgreementResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _serviceLevelAgreementAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(ServiceLevelAgreementResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _serviceLevelAgreementAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<ServiceLevelAgreementResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _serviceLevelAgreementAppService.GetAllAsync();

            return Ok(response);
        }

         [HttpGet]
        [Route("GetAllUsarioLogado")]
        [ProducesResponseType(typeof(IEnumerable<ServiceLevelAgreementResponseDTO>), 200)]
        public async Task<IActionResult> GetAllUsarioLogadoAsync()
        {
            var response = await _serviceLevelAgreementAppService.GetAllUsarioLogadoAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<ServiceLevelAgreementResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _serviceLevelAgreementAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
