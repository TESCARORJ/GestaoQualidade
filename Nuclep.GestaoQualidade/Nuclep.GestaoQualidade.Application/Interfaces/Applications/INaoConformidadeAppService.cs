using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface INaoConformidadeAppService : IDisposable
    {

        Task GararPerguntasAsync();
        Task<NaoConformidadeResponseDTO> UpdateAsync(long id, NaoConformidadeRequestDTO request);
        Task<NaoConformidadeResponseDTO> DeleteAsync(long id);
        Task<NaoConformidadeResponseDTO> GetByIdAsync(long id);
        Task<List<NaoConformidadeResponseDTO>> GetAllAsync();
        Task<List<NaoConformidadeResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<NaoConformidadeResponseDTO>> GetAllAtivosAsync();
    }
}
