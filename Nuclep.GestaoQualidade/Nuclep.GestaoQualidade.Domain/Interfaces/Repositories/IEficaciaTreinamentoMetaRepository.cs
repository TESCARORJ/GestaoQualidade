using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IEficaciaTreinamentoMetaRepository : IBaseRepository<EficaciaTreinamentoMeta, long>
    {
        Task<EficaciaTreinamentoMeta?> GetOneAsync(Expression<Func<EficaciaTreinamentoMeta, bool>> where);
        Task<EficaciaTreinamentoMeta?> GetByIdAsync(long id);
        Task<List<EficaciaTreinamentoMeta>> GetAllAsync();
        Task<List<EficaciaTreinamentoMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<EficaciaTreinamentoMeta>> GetAllAtivosAsync();
    }
}
