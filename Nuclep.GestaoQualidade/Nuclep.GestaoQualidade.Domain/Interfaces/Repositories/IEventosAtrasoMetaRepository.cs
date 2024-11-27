using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IEventosAtrasoMetaRepository : IBaseRepository<EventosAtrasoMeta, long>
    {
        Task<EventosAtrasoMeta?> GetOneAsync(Expression<Func<EventosAtrasoMeta, bool>> where);
        Task<EventosAtrasoMeta?> GetByIdAsync(long id);
        Task<List<EventosAtrasoMeta>> GetAllAsync();
        Task<List<EventosAtrasoMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<EventosAtrasoMeta>> GetAllAtivosAsync();
    }
}
