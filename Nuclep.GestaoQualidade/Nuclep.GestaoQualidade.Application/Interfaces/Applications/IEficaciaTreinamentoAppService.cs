using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IEficaciaTreinamentoAppService :  IDisposable
    {
        Task GararPerguntasAsync();
        Task<EficaciaTreinamentoResponseDTO> UpdateAsync(long id, EficaciaTreinamentoRequestDTO request);  
        Task<EficaciaTreinamentoResponseDTO> DeleteAsync(long id);
        Task<EficaciaTreinamentoResponseDTO> GetByIdAsync(long id);
        Task<List<EficaciaTreinamentoResponseDTO>> GetAllAsync();
        Task<List<EficaciaTreinamentoResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<EficaciaTreinamentoResponseDTO>> GetAllAtivosAsync();
    }
}
