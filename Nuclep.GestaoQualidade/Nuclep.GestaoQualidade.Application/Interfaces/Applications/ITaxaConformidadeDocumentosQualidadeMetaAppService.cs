using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ITaxaConformidadeDocumentosQualidadeMetaAppService : IDisposable
    {
        Task<TaxaConformidadeDocumentosQualidadeMetaResponseDTO> AddAsync(TaxaConformidadeDocumentosQualidadeMetaRequestDTO request);
        Task<TaxaConformidadeDocumentosQualidadeMetaResponseDTO> UpdateAsync(long id, TaxaConformidadeDocumentosQualidadeMetaRequestDTO request);
        Task<TaxaConformidadeDocumentosQualidadeMetaResponseDTO> DeleteAsync(long id);
        Task<TaxaConformidadeDocumentosQualidadeMetaResponseDTO> GetByIdAsync(long id);
        Task<List<TaxaConformidadeDocumentosQualidadeMetaResponseDTO>> GetAllAsync();
        Task<List<TaxaConformidadeDocumentosQualidadeMetaResponseDTO>> GetAllAtivosAsync();
    }
    
}
