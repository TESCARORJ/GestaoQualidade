using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ISatisfacaoClientesAppService : IDisposable
    {

        Task GararPerguntasAsync();
        Task<SatisfacaoClientesResponseDTO> UpdateAsync(long id, SatisfacaoClientesRequestDTO request);
        Task<SatisfacaoClientesResponseDTO> DeleteAsync(long id);
        Task<SatisfacaoClientesResponseDTO> GetByIdAsync(long id);
        Task<List<SatisfacaoClientesResponseDTO>> GetAllAsync();
        Task<List<SatisfacaoClientesResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<SatisfacaoClientesResponseDTO>> GetAllAtivosAsync();
    }
}
