using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class ServiceLevelAgreementMetaDomainService : IServiceLevelAgreementMetaDomainService
    {
        private readonly IServiceLevelAgreementMetaRepository _serviceLevelAgreementMetaRepository;

        public ServiceLevelAgreementMetaDomainService(
            IServiceLevelAgreementMetaRepository serviceLevelAgreementMetaRepository)
        {
            _serviceLevelAgreementMetaRepository = serviceLevelAgreementMetaRepository;
        }

        public async Task<ServiceLevelAgreementMeta> AddAsync(ServiceLevelAgreementMeta entity)
        {
            await _serviceLevelAgreementMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<ServiceLevelAgreementMeta> UpdateAsync(ServiceLevelAgreementMeta entity)
        {
            if (!await _serviceLevelAgreementMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Tempo Médio Solução com ID {entity.Id} não encontrada.");
            }

            var model = GetByIdAsync(entity.Id).Result;

            entity.DataHoraCadastro = model.DataHoraCadastro;
            entity.UsuarioCadastroId = model.UsuarioCadastroId;
            entity.IsAtivo = model.IsAtivo;

            await _serviceLevelAgreementMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<ServiceLevelAgreementMeta> DeleteAsync(long id)
        {
            var registro = await _serviceLevelAgreementMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Tempo Médio Solução com ID {id} não encontrada.");
            }

            await _serviceLevelAgreementMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<ServiceLevelAgreementMeta?> GetByIdAsync(long id)
        {
            var registro = await _serviceLevelAgreementMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Tempo Médio Solução com ID {id} não encontrada.");
            }

            return registro;
        }


        public async Task<List<ServiceLevelAgreementMeta>> GetAllAsync()
        {
            var registros = await _serviceLevelAgreementMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }

        public async Task<List<ServiceLevelAgreementMeta>> GetAllAtivosAsync()
        {
            var registros = await _serviceLevelAgreementMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }
        public void Dispose()
        {
            _serviceLevelAgreementMetaRepository.Dispose();
        }

    }
}
