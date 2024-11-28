using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IEficaciaTreinamentoRepository : IBaseRepository<EficaciaTreinamento, long>
    {
        Task<EficaciaTreinamento?> GetOneAsync(Expression<Func<EficaciaTreinamento, bool>> where);
        Task<EficaciaTreinamento?> GetByIdAsync(long id);
        Task<List<EficaciaTreinamento>> GetAllAsync();
        Task<List<EficaciaTreinamento>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<EficaciaTreinamento>> GetAllAtivosAsync();
    }
}
