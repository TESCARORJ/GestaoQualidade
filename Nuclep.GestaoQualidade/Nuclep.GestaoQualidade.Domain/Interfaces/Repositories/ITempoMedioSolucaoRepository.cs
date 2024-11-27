using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ITempoMedioSolucaoRepository : IBaseRepository<TempoMedioSolucao, long>
    {
        Task<TempoMedioSolucao?> GetOneAsync(Expression<Func<TempoMedioSolucao, bool>> where);
        Task<TempoMedioSolucao?> GetByIdAsync(long id);
        Task<List<TempoMedioSolucao>> GetAllAsync();
        Task<List<TempoMedioSolucao>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoMedioSolucao>> GetAllAtivosAsync();
    }
}
