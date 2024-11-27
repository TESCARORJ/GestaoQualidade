using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IDefeitoSoldagemAppService : IDisposable
    {

        Task GararPerguntasAsync();
        Task<DefeitoSoldagemResponseDTO> UpdateAsync(long id, DefeitoSoldagemRequestDTO request);
        Task<DefeitoSoldagemResponseDTO> DeleteAsync(long id);
        Task<DefeitoSoldagemResponseDTO> GetByIdAsync(long id);
        Task<List<DefeitoSoldagemResponseDTO>> GetAllAsync();
        Task<List<DefeitoSoldagemResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<DefeitoSoldagemResponseDTO>> GetAllAtivosAsync();
    }
}
