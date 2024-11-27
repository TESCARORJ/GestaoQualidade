using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ICumprimentoVerbaDestinadaPATMMEAppService :  IDisposable
    {
        Task GararPerguntasAsync();
        Task<CumprimentoVerbaDestinadaPATMMEResponseDTO> UpdateAsync(long id, CumprimentoVerbaDestinadaPATMMERequestDTO request);  
        Task<CumprimentoVerbaDestinadaPATMMEResponseDTO> DeleteAsync(long id);
        Task<CumprimentoVerbaDestinadaPATMMEResponseDTO> GetByIdAsync(long id);
        Task<List<CumprimentoVerbaDestinadaPATMMEResponseDTO>> GetAllAsync();
        Task<List<CumprimentoVerbaDestinadaPATMMEResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<CumprimentoVerbaDestinadaPATMMEResponseDTO>> GetAllAtivosAsync();
    }
}
