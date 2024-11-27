using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IAcaoDentroPrazoMetaRepository : IBaseRepository<AcaoDentroPrazoMeta, long>
    {
        Task<AcaoDentroPrazoMeta?> GetOneAsync(Expression<Func<AcaoDentroPrazoMeta, bool>> where);
        Task<AcaoDentroPrazoMeta?> GetByIdAsync(long id);
        Task<List<AcaoDentroPrazoMeta>> GetAllAsync();
        Task<List<AcaoDentroPrazoMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<AcaoDentroPrazoMeta>> GetAllAtivosAsync();
    }
}
