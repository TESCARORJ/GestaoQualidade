using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class LogCrudDomainService : ILogCrudDomainService
    {
        private readonly ILogCrudRepository _logCrudRepository;

        public LogCrudDomainService(
            ILogCrudRepository logCrudRepository
            )
        {
            _logCrudRepository = logCrudRepository;
        }



        public async Task<List<LogCrud>> GetAllAsync()
        {
            var registros = await  _logCrudRepository.GetAll();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

      

    }
}

