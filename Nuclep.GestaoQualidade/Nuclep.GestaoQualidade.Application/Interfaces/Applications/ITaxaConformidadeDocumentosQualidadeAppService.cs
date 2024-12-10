using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ITaxaConformidadeDocumentosQualidadeAppService :  IDisposable
    {
        Task GararPerguntasAsync();

        //Task<TaxaConformidadeDocumentosQualidadeResponseDTO> AddAsync(TaxaConformidadeDocumentosQualidadeRequestDTO request);

        Task<TaxaConformidadeDocumentosQualidadeResponseDTO> UpdateAsync(long id, TaxaConformidadeDocumentosQualidadeRequestDTO request);  
        Task<TaxaConformidadeDocumentosQualidadeResponseDTO> DeleteAsync(long id);
        Task<TaxaConformidadeDocumentosQualidadeResponseDTO> GetByIdAsync(long id);
        Task<List<TaxaConformidadeDocumentosQualidadeResponseDTO>> GetAllAsync();
        Task<List<TaxaConformidadeDocumentosQualidadeResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<TaxaConformidadeDocumentosQualidadeResponseDTO>> GetAllAtivosAsync();
    }
}
