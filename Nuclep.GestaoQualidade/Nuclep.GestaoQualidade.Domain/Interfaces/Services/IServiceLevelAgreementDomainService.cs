using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IServiceLevelAgreementDomainService : IDisposable
    {
        Task<ServiceLevelAgreement> AddAsync(ServiceLevelAgreement entity);
        Task<List<ServiceLevelAgreement>> AddListAsync(List<ServiceLevelAgreement> entity);
        Task<ServiceLevelAgreement> UpdateAsync(ServiceLevelAgreement entity);
        Task<ServiceLevelAgreement> DeleteAsync(long id);
        Task<ServiceLevelAgreement> GetByIdAsync(long id);
        Task<List<ServiceLevelAgreement>> GetAllAsync();
        Task<List<ServiceLevelAgreement>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<ServiceLevelAgreement>> GetAllAtivosAsync();
    }
}