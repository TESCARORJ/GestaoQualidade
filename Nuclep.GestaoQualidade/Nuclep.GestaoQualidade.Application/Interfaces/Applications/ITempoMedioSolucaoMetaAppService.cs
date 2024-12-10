using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ITempoMedioSolucaoMetaAppService : IDisposable
    {
        Task<TempoMedioSolucaoMetaResponseDTO> AddAsync(TempoMedioSolucaoMetaRequestDTO request);
        Task<TempoMedioSolucaoMetaResponseDTO> UpdateAsync(long id, TempoMedioSolucaoMetaRequestDTO request);
        Task<TempoMedioSolucaoMetaResponseDTO> DeleteAsync(long id);
        Task<TempoMedioSolucaoMetaResponseDTO> GetByIdAsync(long id);
        Task<List<TempoMedioSolucaoMetaResponseDTO>> GetAllAsync();
        Task<List<TempoMedioSolucaoMetaResponseDTO>> GetAllAtivosAsync();
    }

}
