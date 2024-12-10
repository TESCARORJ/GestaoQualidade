using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class LocalidadeDomainService : ILocalidadeDomainService
    {
        private readonly ILocalidadeRepository _localidadeRepository;

        public LocalidadeDomainService(
            ILocalidadeRepository localidadeRepository
            )
        {
            _localidadeRepository = localidadeRepository;
        }

        public async Task<Localidade> AddAsync(Localidade entity)
        {
            await _localidadeRepository.AddAsync(entity);
            return entity;
        }

        public async Task<Localidade> UpdateAsync(Localidade entity)
        {
            if (!await _localidadeRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Localide com ID {entity.Id} não foi encontrada ");
            }

            try
            {
                await _localidadeRepository.UpdateAsync(entity);

            }
            catch (Exception ex)
            {

                throw;
            }

            return entity;

        }

        public async Task<Localidade> DeleteAsync(long id)
        {
            var registro = await _localidadeRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Localidade com ID {id} não foi encontrado ");
            }

            await _localidadeRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<Localidade?> GetByIdAsync(long id)
        {
            var registro = await _localidadeRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Localidade com ID {id} não foi encontrado ");
            }

            return registro;
        }

        public async Task<Localidade?> GetByNameAsync(string nome)
        {
            var registro = await _localidadeRepository.GetOneAsync(x => x.Nome == nome);

            if (registro == null)
            {
                throw new Exception($"Localidade com Nome {nome} não foi encontrado");
            }

            return registro;
        }

         public async Task<Localidade?> GetByLoginAsync(string login)
        {
            var registro = await _localidadeRepository.GetOneAsync(x => x.NomeAD == login);

            if (registro == null)
            {
                throw new Exception($"Localidade com Nome {login} não foi encontrado");
            }

            return registro;
        }

        

        public async Task<List<Localidade>> GetByNameListAsync(string nome)
        { 
           var  registro =   _localidadeRepository.GetAllAsync().Result.Where(x => x.Nome == nome).ToList();

            if (registro == null)
            {
                throw new Exception($"Localidade com Nome {nome} não foi encontrado");
            }

            return registro;
        }


        public async Task<List<Localidade>> GetAllAsync()
        {
            var registros = await _localidadeRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<Localidade>> GetAllAtivosAsync()
        {
            var registros = await _localidadeRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }

      

        public void Dispose()
        {
            _localidadeRepository.Dispose();
        }

    }
}

