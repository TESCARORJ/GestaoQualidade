using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class ServiceLevelAgreementDomainService : IServiceLevelAgreementDomainService
    {
        private readonly IServiceLevelAgreementRepository _serviceLevelAgreementRepository;

        public ServiceLevelAgreementDomainService(
            IServiceLevelAgreementRepository serviceLevelAgreementRepository)
        {
            _serviceLevelAgreementRepository = serviceLevelAgreementRepository;
        }

        public async Task<ServiceLevelAgreement> AddAsync(ServiceLevelAgreement entity)
        {
            await _serviceLevelAgreementRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<ServiceLevelAgreement>> AddListAsync(List<ServiceLevelAgreement> entity)
        {
            foreach (var item in entity)
            {
                await _serviceLevelAgreementRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<ServiceLevelAgreement> UpdateAsync(ServiceLevelAgreement entity)
        {
            if (!await _serviceLevelAgreementRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Tempo Médio Solução com ID {entity.Id} não encontrada.");
            }

            await _serviceLevelAgreementRepository.UpdateAsync(entity);

            return entity;

        }

        public async Task<ServiceLevelAgreement> DeleteAsync(long id)
        {
            var registro = await _serviceLevelAgreementRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Tempo Médio Solução com ID {id} não encontrada.");
            }

            await _serviceLevelAgreementRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<ServiceLevelAgreement?> GetByIdAsync(long id)
        {
            var registro = await _serviceLevelAgreementRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Tempo Médio Solução com ID {id} não encontrada.");
            }

            return registro;
        }

        public Task<List<ServiceLevelAgreement>> GetAllAsync()
        {
            var registro = _serviceLevelAgreementRepository.GetAllAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }
        public Task<List<ServiceLevelAgreement>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registro = _serviceLevelAgreementRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public Task<List<ServiceLevelAgreement>> GetAllAtivosAsync()
        {
            var registro = _serviceLevelAgreementRepository.GetAllAtivosAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public void Dispose()
        {
            _serviceLevelAgreementRepository.Dispose();
        }


    }
}
