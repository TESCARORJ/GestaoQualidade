using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IAcaoDentroPrazoRepository : IBaseRepository<AcaoDentroPrazo, long>
    {
        Task<AcaoDentroPrazo?> GetOneAsync(Expression<Func<AcaoDentroPrazo, bool>> where);
        Task<AcaoDentroPrazo?> GetByIdAsync(long id);
        Task<List<AcaoDentroPrazo>> GetAllAsync();
        Task<List<AcaoDentroPrazo>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<AcaoDentroPrazo>> GetAllAtivosAsync();
    }
}
