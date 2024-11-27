using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IReducaoRNCMetaRepository : IBaseRepository<ReducaoRNCMeta, long>
    {
        Task<ReducaoRNCMeta?> GetOneAsync(Expression<Func<ReducaoRNCMeta, bool>> where);
        Task<ReducaoRNCMeta?> GetByIdAsync(long id);
        Task<List<ReducaoRNCMeta>> GetAllAsync();
        Task<List<ReducaoRNCMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<ReducaoRNCMeta>> GetAllAtivosAsync();
    }
}
