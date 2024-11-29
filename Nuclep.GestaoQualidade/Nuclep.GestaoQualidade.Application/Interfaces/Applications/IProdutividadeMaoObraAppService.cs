using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IProdutividadeMaoObraAppService : IDisposable
    {

        Task GararPerguntasAsync();
        Task<ProdutividadeMaoObraResponseDTO> UpdateAsync(long id, ProdutividadeMaoObraRequestDTO request);
        Task<ProdutividadeMaoObraResponseDTO> DeleteAsync(long id);
        Task<ProdutividadeMaoObraResponseDTO> GetByIdAsync(long id);
        Task<List<ProdutividadeMaoObraResponseDTO>> GetAllAsync();
        Task<List<ProdutividadeMaoObraResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<ProdutividadeMaoObraResponseDTO>> GetAllAtivosAsync();
    }
}
