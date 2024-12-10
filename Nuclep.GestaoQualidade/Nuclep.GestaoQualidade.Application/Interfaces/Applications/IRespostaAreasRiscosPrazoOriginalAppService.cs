using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IRespostaAreasRiscosPrazoOriginalAppService :  IDisposable
    {
        Task GararPerguntasAsync();

        Task<RespostaAreasRiscosPrazoOriginalResponseDTO> UpdateAsync(long id, RespostaAreasRiscosPrazoOriginalRequestDTO request);  
        Task<RespostaAreasRiscosPrazoOriginalResponseDTO> DeleteAsync(long id);
        Task<RespostaAreasRiscosPrazoOriginalResponseDTO> GetByIdAsync(long id);
        Task<List<RespostaAreasRiscosPrazoOriginalResponseDTO>> GetAllAsync();
        Task<List<RespostaAreasRiscosPrazoOriginalResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<RespostaAreasRiscosPrazoOriginalResponseDTO>> GetAllAtivosAsync();
    }
}
