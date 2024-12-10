using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ITempoMedioEmissaoOCItensCriticosMetaDomainService : IDisposable
    {
        Task<TempoMedioEmissaoOCItensCriticosMeta> AddAsync(TempoMedioEmissaoOCItensCriticosMeta entity);
        Task<TempoMedioEmissaoOCItensCriticosMeta> UpdateAsync(TempoMedioEmissaoOCItensCriticosMeta entity);
        Task<TempoMedioEmissaoOCItensCriticosMeta> DeleteAsync(long id);
        Task<TempoMedioEmissaoOCItensCriticosMeta> GetByIdAsync(long id);
        Task<List<TempoMedioEmissaoOCItensCriticosMeta>> GetAllAsync();
        Task<List<TempoMedioEmissaoOCItensCriticosMeta>> GetAllAtivosAsync(); 
    }
}