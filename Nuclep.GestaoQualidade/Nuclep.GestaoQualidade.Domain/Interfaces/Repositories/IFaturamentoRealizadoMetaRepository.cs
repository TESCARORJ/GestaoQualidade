using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IFaturamentoRealizadoMetaRepository : IBaseRepository<FaturamentoRealizadoMeta, long>
    {
        Task<FaturamentoRealizadoMeta?> GetOneAsync(Expression<Func<FaturamentoRealizadoMeta, bool>> where);
        Task<FaturamentoRealizadoMeta?> GetByIdAsync(long id);
        Task<List<FaturamentoRealizadoMeta>> GetAllAsync();
        Task<List<FaturamentoRealizadoMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<FaturamentoRealizadoMeta>> GetAllAtivosAsync();
    }
}
