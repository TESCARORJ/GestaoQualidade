using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ITempoMedioSolucaoMetaRepository : IBaseRepository<TempoMedioSolucaoMeta, long>
    {
        Task<TempoMedioSolucaoMeta?> GetOneAsync(Expression<Func<TempoMedioSolucaoMeta, bool>> where);
        Task<TempoMedioSolucaoMeta?> GetByIdAsync(long id);
        Task<List<TempoMedioSolucaoMeta>> GetAllAsync();
        Task<List<TempoMedioSolucaoMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoMedioSolucaoMeta>> GetAllAtivosAsync();
    }
}
