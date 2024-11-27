using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IDuracaoProcessoLicitacaoAppService :  IDisposable
    {
        Task GararPerguntasAsync();

        //Task<DuracaoProcessoLicitacaoResponseDTO> AddAsync(DuracaoProcessoLicitacaoRequestDTO request);

        Task<DuracaoProcessoLicitacaoResponseDTO> UpdateAsync(long id, DuracaoProcessoLicitacaoRequestDTO request);  
        Task<DuracaoProcessoLicitacaoResponseDTO> DeleteAsync(long id);
        Task<DuracaoProcessoLicitacaoResponseDTO> GetByIdAsync(long id);
        Task<List<DuracaoProcessoLicitacaoResponseDTO>> GetAllAsync();
        Task<List<DuracaoProcessoLicitacaoResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<DuracaoProcessoLicitacaoResponseDTO>> GetAllAtivosAsync();
    }
}
