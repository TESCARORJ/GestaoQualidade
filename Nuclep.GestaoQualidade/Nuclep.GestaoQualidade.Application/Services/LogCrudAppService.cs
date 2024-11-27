using AutoMapper;
using Microsoft.AspNetCore.Http;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;

namespace Nuclep.GestaoQualidade.Application.Services
{
    public class LogCrudAppService : ILogCrudAppService
    {
        private readonly ILogCrudDomainService _logCrudDomainService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
       


        public LogCrudAppService(
            ILogCrudDomainService LogCrudDomainService,
            IMapper mapper,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository)
        {
            _logCrudDomainService = LogCrudDomainService;
            _mapper = mapper;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
          
        }

      

        public async Task<List<LogCrudResponseDTO>> GetAllAsync()
        {
            var result = await _logCrudDomainService.GetAllAsync();
            return _mapper.Map<List<LogCrudResponseDTO>>(result);
        }

       

    }
}
