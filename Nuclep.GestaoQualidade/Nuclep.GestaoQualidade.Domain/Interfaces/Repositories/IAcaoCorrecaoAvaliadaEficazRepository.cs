using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IAcaoCorrecaoAvaliadaEficazRepository : IBaseRepository<AcaoCorrecaoAvaliadaEficaz, long>
    {
        Task<AcaoCorrecaoAvaliadaEficaz?> GetOneAsync(Expression<Func<AcaoCorrecaoAvaliadaEficaz, bool>> where);
        Task<AcaoCorrecaoAvaliadaEficaz?> GetByIdAsync(long id);
        Task<List<AcaoCorrecaoAvaliadaEficaz>> GetAllAsync();
        Task<List<AcaoCorrecaoAvaliadaEficaz>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<AcaoCorrecaoAvaliadaEficaz>> GetAllAtivosAsync();
    }
}
