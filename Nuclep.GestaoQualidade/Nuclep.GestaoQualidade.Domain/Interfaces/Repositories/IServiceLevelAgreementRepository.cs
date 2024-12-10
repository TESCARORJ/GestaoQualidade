using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IServiceLevelAgreementRepository : IBaseRepository<ServiceLevelAgreement, long>
    {
        Task<ServiceLevelAgreement?> GetOneAsync(Expression<Func<ServiceLevelAgreement, bool>> where);
        Task<ServiceLevelAgreement?> GetByIdAsync(long id);
        Task<List<ServiceLevelAgreement>> GetAllAsync();
        Task<List<ServiceLevelAgreement>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<ServiceLevelAgreement>> GetAllAtivosAsync();
    }
}
