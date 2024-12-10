using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IServiceLevelAgreementMetaRepository : IBaseRepository<ServiceLevelAgreementMeta, long>
    {
        Task<ServiceLevelAgreementMeta?> GetOneAsync(Expression<Func<ServiceLevelAgreementMeta, bool>> where);
        Task<ServiceLevelAgreementMeta?> GetByIdAsync(long id);
        Task<List<ServiceLevelAgreementMeta>> GetAllAsync();
        Task<List<ServiceLevelAgreementMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<ServiceLevelAgreementMeta>> GetAllAtivosAsync();
    }
}
