using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IOcupacaoMaoObraAppService : IDisposable
    {

        Task GararPerguntasAsync();
        Task<OcupacaoMaoObraResponseDTO> UpdateAsync(long id, OcupacaoMaoObraRequestDTO request);
        Task<OcupacaoMaoObraResponseDTO> DeleteAsync(long id);
        Task<OcupacaoMaoObraResponseDTO> GetByIdAsync(long id);
        Task<List<OcupacaoMaoObraResponseDTO>> GetAllAsync();
        Task<List<OcupacaoMaoObraResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<OcupacaoMaoObraResponseDTO>> GetAllAtivosAsync();
    }
}
