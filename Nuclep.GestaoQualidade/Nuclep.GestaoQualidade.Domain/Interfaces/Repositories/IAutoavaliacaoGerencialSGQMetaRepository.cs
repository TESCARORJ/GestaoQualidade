using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IAutoavaliacaoGerencialSGQMetaRepository : IBaseRepository<AutoavaliacaoGerencialSGQMeta, long>
    {
        Task<AutoavaliacaoGerencialSGQMeta?> GetOneAsync(Expression<Func<AutoavaliacaoGerencialSGQMeta, bool>> where);
        Task<AutoavaliacaoGerencialSGQMeta?> GetByIdAsync(long id);
        Task<List<AutoavaliacaoGerencialSGQMeta>> GetAllAsync();
        Task<List<AutoavaliacaoGerencialSGQMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<AutoavaliacaoGerencialSGQMeta>> GetAllAtivosAsync();
    }
}
