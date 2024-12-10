using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ISatisfacaoUsuarioAppService : IDisposable
    {

        Task GararPerguntasAsync();
        Task<SatisfacaoUsuarioResponseDTO> UpdateAsync(long id, SatisfacaoUsuarioRequestDTO request);
        Task<SatisfacaoUsuarioResponseDTO> DeleteAsync(long id);
        Task<SatisfacaoUsuarioResponseDTO> GetByIdAsync(long id);
        Task<List<SatisfacaoUsuarioResponseDTO>> GetAllAsync();
        Task<List<SatisfacaoUsuarioResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<SatisfacaoUsuarioResponseDTO>> GetAllAtivosAsync();
    }
}
