using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IAcaoCorrecaoAvaliadaEficazMetaRepository : IBaseRepository<AcaoCorrecaoAvaliadaEficazMeta, long>
    {
        Task<AcaoCorrecaoAvaliadaEficazMeta?> GetOneAsync(Expression<Func<AcaoCorrecaoAvaliadaEficazMeta, bool>> where);
        Task<AcaoCorrecaoAvaliadaEficazMeta?> GetByIdAsync(long id);
        Task<List<AcaoCorrecaoAvaliadaEficazMeta>> GetAllAsync();
        Task<List<AcaoCorrecaoAvaliadaEficazMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<AcaoCorrecaoAvaliadaEficazMeta>> GetAllAtivosAsync();
    }
}
