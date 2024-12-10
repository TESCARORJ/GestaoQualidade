using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ITempoMedioEmissaoOCItensCriticosDomainService : IDisposable
    {
        Task<TempoMedioEmissaoOCItensCriticos> AddAsync(TempoMedioEmissaoOCItensCriticos entity);
        Task<List<TempoMedioEmissaoOCItensCriticos>> AddListAsync(List<TempoMedioEmissaoOCItensCriticos> entity);
        Task<TempoMedioEmissaoOCItensCriticos> UpdateAsync(TempoMedioEmissaoOCItensCriticos entity);
        Task<TempoMedioEmissaoOCItensCriticos> DeleteAsync(long id);
        Task<TempoMedioEmissaoOCItensCriticos> GetByIdAsync(long id);
        Task<List<TempoMedioEmissaoOCItensCriticos>> GetAllAsync();
        Task<List<TempoMedioEmissaoOCItensCriticos>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoMedioEmissaoOCItensCriticos>> GetAllAtivosAsync(); 
    }
}