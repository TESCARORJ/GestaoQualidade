using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ITempoMedioSolucaoAppService : IDisposable
    {

        Task GararPerguntasAsync();
        Task<TempoMedioSolucaoResponseDTO> UpdateAsync(long id, TempoMedioSolucaoRequestDTO request);
        Task<TempoMedioSolucaoResponseDTO> DeleteAsync(long id);
        Task<TempoMedioSolucaoResponseDTO> GetByIdAsync(long id);
        Task<List<TempoMedioSolucaoResponseDTO>> GetAllAsync();
        Task<List<TempoMedioSolucaoResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<TempoMedioSolucaoResponseDTO>> GetAllAtivosAsync();
    }
}
