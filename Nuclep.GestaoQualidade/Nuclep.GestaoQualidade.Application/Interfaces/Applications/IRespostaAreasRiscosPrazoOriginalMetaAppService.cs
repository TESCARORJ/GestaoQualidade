using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IRespostaAreasRiscosPrazoOriginalMetaAppService : IDisposable
    {
        Task<RespostaAreasRiscosPrazoOriginalMetaResponseDTO> AddAsync(RespostaAreasRiscosPrazoOriginalMetaRequestDTO request);
        Task<RespostaAreasRiscosPrazoOriginalMetaResponseDTO> UpdateAsync(long id, RespostaAreasRiscosPrazoOriginalMetaRequestDTO request);
        Task<RespostaAreasRiscosPrazoOriginalMetaResponseDTO> DeleteAsync(long id);
        Task<RespostaAreasRiscosPrazoOriginalMetaResponseDTO> GetByIdAsync(long id);
        Task<List<RespostaAreasRiscosPrazoOriginalMetaResponseDTO>> GetAllAsync();
        Task<List<RespostaAreasRiscosPrazoOriginalMetaResponseDTO>> GetAllAtivosAsync();
    }
    
}
