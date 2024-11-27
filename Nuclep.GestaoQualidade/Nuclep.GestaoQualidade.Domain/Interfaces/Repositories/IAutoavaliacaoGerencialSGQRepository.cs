using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IAutoavaliacaoGerencialSGQRepository : IBaseRepository<AutoavaliacaoGerencialSGQ, long>
    {
        Task<AutoavaliacaoGerencialSGQ?> GetOneAsync(Expression<Func<AutoavaliacaoGerencialSGQ, bool>> where);
        Task<AutoavaliacaoGerencialSGQ?> GetByIdAsync(long id);
        Task<List<AutoavaliacaoGerencialSGQ>> GetAllAsync();
        Task<List<AutoavaliacaoGerencialSGQ>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<AutoavaliacaoGerencialSGQ>> GetAllAtivosAsync();
    }
}
