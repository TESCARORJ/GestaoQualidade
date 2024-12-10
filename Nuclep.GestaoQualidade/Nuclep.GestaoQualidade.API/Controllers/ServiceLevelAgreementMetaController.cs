using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceLevelAgreementMetaController : ControllerBase
    {
        private readonly IServiceLevelAgreementMetaAppService _serviceLevelAgreementMetaAppService;

        public ServiceLevelAgreementMetaController(IServiceLevelAgreementMetaAppService serviceLevelAgreementMetaAppService)
        {
            _serviceLevelAgreementMetaAppService = serviceLevelAgreementMetaAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ServiceLevelAgreementMetaResponseDTO), 201)]
        public async Task<IActionResult> AddAsync([FromBody] ServiceLevelAgreementMetaRequestDTO request)
        {
            var response = await _serviceLevelAgreementMetaAppService.AddAsync(request);

            return StatusCode(201, response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ServiceLevelAgreementMetaResponseDTO), 200)]
        public async Task<IActionResult> UpdateAsync(long id, [FromBody] ServiceLevelAgreementMetaRequestDTO request)
        {
            var response = await _serviceLevelAgreementMetaAppService.UpdateAsync(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ServiceLevelAgreementMetaResponseDTO), 200)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var response = await _serviceLevelAgreementMetaAppService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpGet("id/{id}")]
        [ProducesResponseType(typeof(ServiceLevelAgreementMetaResponseDTO), 200)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var response = await _serviceLevelAgreementMetaAppService.GetByIdAsync(id);

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<ServiceLevelAgreementMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _serviceLevelAgreementMetaAppService.GetAllAsync();

            return Ok(response);
        }


        [HttpGet]
        [Route("GetAllAtivos")]
        [ProducesResponseType(typeof(IEnumerable<ServiceLevelAgreementMetaResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAtivosAsync()
        {
            var response = await _serviceLevelAgreementMetaAppService.GetAllAtivosAsync();

            return Ok(response);
        }


    }
}
