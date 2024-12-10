using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ITempoMedioEmissaoOCItensCriticosRepository : IBaseRepository<TempoMedioEmissaoOCItensCriticos, long>
    {
        Task<TempoMedioEmissaoOCItensCriticos?> GetOneAsync(Expression<Func<TempoMedioEmissaoOCItensCriticos, bool>> where);
        Task<TempoMedioEmissaoOCItensCriticos?> GetByIdAsync(long id);
        Task<List<TempoMedioEmissaoOCItensCriticos>> GetAllAsync();
        Task<List<TempoMedioEmissaoOCItensCriticos>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoMedioEmissaoOCItensCriticos>> GetAllAtivosAsync();
    }
}
