using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ITempoMedioEmissaoOCItensCriticosMetaAppService : IDisposable
    {
        Task<TempoMedioEmissaoOCItensCriticosMetaResponseDTO> AddAsync(TempoMedioEmissaoOCItensCriticosMetaRequestDTO request);
        Task<TempoMedioEmissaoOCItensCriticosMetaResponseDTO> UpdateAsync(long id, TempoMedioEmissaoOCItensCriticosMetaRequestDTO request);
        Task<TempoMedioEmissaoOCItensCriticosMetaResponseDTO> DeleteAsync(long id);
        Task<TempoMedioEmissaoOCItensCriticosMetaResponseDTO> GetByIdAsync(long id);
        Task<List<TempoMedioEmissaoOCItensCriticosMetaResponseDTO>> GetAllAsync();
        Task<List<TempoMedioEmissaoOCItensCriticosMetaResponseDTO>> GetAllAtivosAsync();
    }

}
