using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IFaturamentoRealizadoAppService :  IDisposable
    {
        Task GararPerguntasAsync();

        //Task<FaturamentoRealizadoResponseDTO> AddAsync(FaturamentoRealizadoRequestDTO request);

        Task<FaturamentoRealizadoResponseDTO> UpdateAsync(long id, FaturamentoRealizadoRequestDTO request);  
        Task<FaturamentoRealizadoResponseDTO> DeleteAsync(long id);
        Task<FaturamentoRealizadoResponseDTO> GetByIdAsync(long id);
        Task<List<FaturamentoRealizadoResponseDTO>> GetAllAsync();
        Task<List<FaturamentoRealizadoResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<FaturamentoRealizadoResponseDTO>> GetAllAtivosAsync();
    }
}
