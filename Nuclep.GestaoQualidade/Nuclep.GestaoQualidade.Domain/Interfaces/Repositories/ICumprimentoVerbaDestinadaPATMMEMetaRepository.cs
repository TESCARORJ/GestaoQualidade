using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ICumprimentoVerbaDestinadaPATMMEMetaRepository : IBaseRepository<CumprimentoVerbaDestinadaPATMMEMeta, long>
    {
        Task<CumprimentoVerbaDestinadaPATMMEMeta?> GetOneAsync(Expression<Func<CumprimentoVerbaDestinadaPATMMEMeta, bool>> where);
        Task<CumprimentoVerbaDestinadaPATMMEMeta?> GetByIdAsync(long id);
        Task<List<CumprimentoVerbaDestinadaPATMMEMeta>> GetAllAsync();
        Task<List<CumprimentoVerbaDestinadaPATMMEMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<CumprimentoVerbaDestinadaPATMMEMeta>> GetAllAtivosAsync();
    }
}
