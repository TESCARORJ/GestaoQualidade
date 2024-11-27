using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IEventosAtrasoRepository : IBaseRepository<EventosAtraso, long>
    {
        Task<EventosAtraso?> GetOneAsync(Expression<Func<EventosAtraso, bool>> where);
        Task<EventosAtraso?> GetByIdAsync(long id);
        Task<List<EventosAtraso>> GetAllAsync();
        Task<List<EventosAtraso>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<EventosAtraso>> GetAllAtivosAsync();
    }
}
