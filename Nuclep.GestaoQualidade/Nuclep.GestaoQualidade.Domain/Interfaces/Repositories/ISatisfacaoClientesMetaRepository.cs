using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ISatisfacaoClientesMetaRepository : IBaseRepository<SatisfacaoClientesMeta, long>
    {
        Task<SatisfacaoClientesMeta?> GetOneAsync(Expression<Func<SatisfacaoClientesMeta, bool>> where);
        Task<SatisfacaoClientesMeta?> GetByIdAsync(long id);
        Task<List<SatisfacaoClientesMeta>> GetAllAsync();
        Task<List<SatisfacaoClientesMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<SatisfacaoClientesMeta>> GetAllAtivosAsync();
    }
}
