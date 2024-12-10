using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ISatisfacaoClientesRepository : IBaseRepository<SatisfacaoClientes, long>
    {
        Task<SatisfacaoClientes?> GetOneAsync(Expression<Func<SatisfacaoClientes, bool>> where);
        Task<SatisfacaoClientes?> GetByIdAsync(long id);
        Task<List<SatisfacaoClientes>> GetAllAsync();
        Task<List<SatisfacaoClientes>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<SatisfacaoClientes>> GetAllAtivosAsync();
    }
}
