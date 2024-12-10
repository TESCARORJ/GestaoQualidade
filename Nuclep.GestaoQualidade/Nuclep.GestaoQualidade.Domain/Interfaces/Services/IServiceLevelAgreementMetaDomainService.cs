using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IServiceLevelAgreementMetaDomainService : IDisposable
    {
        Task<ServiceLevelAgreementMeta> AddAsync(ServiceLevelAgreementMeta entity);
        Task<ServiceLevelAgreementMeta> UpdateAsync(ServiceLevelAgreementMeta entity);
        Task<ServiceLevelAgreementMeta> DeleteAsync(long id);
        Task<ServiceLevelAgreementMeta> GetByIdAsync(long id);
        Task<List<ServiceLevelAgreementMeta>> GetAllAsync();
        Task<List<ServiceLevelAgreementMeta>> GetAllAtivosAsync();
    }
}