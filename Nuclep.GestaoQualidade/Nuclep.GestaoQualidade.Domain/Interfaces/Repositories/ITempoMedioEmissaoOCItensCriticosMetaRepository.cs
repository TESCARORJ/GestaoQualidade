using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ITempoMedioEmissaoOCItensCriticosMetaRepository : IBaseRepository<TempoMedioEmissaoOCItensCriticosMeta, long>
    {
        Task<TempoMedioEmissaoOCItensCriticosMeta?> GetOneAsync(Expression<Func<TempoMedioEmissaoOCItensCriticosMeta, bool>> where);
        Task<TempoMedioEmissaoOCItensCriticosMeta?> GetByIdAsync(long id);
        Task<List<TempoMedioEmissaoOCItensCriticosMeta>> GetAllAsync();
        Task<List<TempoMedioEmissaoOCItensCriticosMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoMedioEmissaoOCItensCriticosMeta>> GetAllAtivosAsync();
    }
}
