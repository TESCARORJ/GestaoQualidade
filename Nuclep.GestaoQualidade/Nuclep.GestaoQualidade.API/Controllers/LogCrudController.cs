using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nuclep.GestaoQualidade.API.Helpers;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogCrudController : ControllerBase
    {
        private readonly ILogCrudAppService _LogCrudAppService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        


        public LogCrudController(ILogCrudAppService LogCrudAppService, IHttpContextAccessor httpContextAccessor)
        {
            _LogCrudAppService = LogCrudAppService;
            _httpContextAccessor = httpContextAccessor;
           
        }

   


        [HttpGet]
        [Route("GetAll")]
        [ProducesResponseType(typeof(IEnumerable<LogCrudResponseDTO>), 200)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _LogCrudAppService.GetAllAsync();

            if (response == null || !response.Any())
            {
                return NotFound("Nenhum usuário localizado");
            }

            var orderedResponse = response.OrderByDescending(x => x.Id);

            return Ok(orderedResponse);
        }





    }
}
