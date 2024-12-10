using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ITempoMedioEmissaoOCItensCriticosAppService : IDisposable
    {

        Task GararPerguntasAsync();
        Task<TempoMedioEmissaoOCItensCriticosResponseDTO> UpdateAsync(long id, TempoMedioEmissaoOCItensCriticosRequestDTO request);
        Task<TempoMedioEmissaoOCItensCriticosResponseDTO> DeleteAsync(long id);
        Task<TempoMedioEmissaoOCItensCriticosResponseDTO> GetByIdAsync(long id);
        Task<List<TempoMedioEmissaoOCItensCriticosResponseDTO>> GetAllAsync();
        Task<List<TempoMedioEmissaoOCItensCriticosResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<TempoMedioEmissaoOCItensCriticosResponseDTO>> GetAllAtivosAsync();
    }
}
