using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IAcaoCorrecaoAvaliadaEficazAppService :  IDisposable
    {
        Task GararPerguntasAsync();

        //Task<AcaoCorrecaoAvaliadaEficazResponseDTO> AddAsync(AcaoCorrecaoAvaliadaEficazRequestDTO request);

        Task<AcaoCorrecaoAvaliadaEficazResponseDTO> UpdateAsync(long id, AcaoCorrecaoAvaliadaEficazRequestDTO request);  
        Task<AcaoCorrecaoAvaliadaEficazResponseDTO> DeleteAsync(long id);
        Task<AcaoCorrecaoAvaliadaEficazResponseDTO> GetByIdAsync(long id);
        Task<List<AcaoCorrecaoAvaliadaEficazResponseDTO>> GetAllAsync();
        Task<List<AcaoCorrecaoAvaliadaEficazResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<AcaoCorrecaoAvaliadaEficazResponseDTO>> GetAllAtivosAsync();
    }
}
