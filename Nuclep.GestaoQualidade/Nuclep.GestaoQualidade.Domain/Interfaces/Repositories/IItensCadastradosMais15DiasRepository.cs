using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IReducaoRNCRepository : IBaseRepository<ReducaoRNC, long>
    {
        Task<ReducaoRNC?> GetOneAsync(Expression<Func<ReducaoRNC, bool>> where);
        Task<ReducaoRNC?> GetByIdAsync(long id);
        Task<List<ReducaoRNC>> GetAllAsync();
        Task<List<ReducaoRNC>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<ReducaoRNC>> GetAllAtivosAsync();
    }
}
