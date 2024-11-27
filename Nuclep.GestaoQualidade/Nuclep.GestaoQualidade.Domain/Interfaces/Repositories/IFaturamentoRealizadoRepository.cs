using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IFaturamentoRealizadoRepository : IBaseRepository<FaturamentoRealizado, long>
    {
        Task<FaturamentoRealizado?> GetOneAsync(Expression<Func<FaturamentoRealizado, bool>> where);
        Task<FaturamentoRealizado?> GetByIdAsync(long id);
        Task<List<FaturamentoRealizado>> GetAllAsync();
        Task<List<FaturamentoRealizado>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<FaturamentoRealizado>> GetAllAtivosAsync();
    }
}
