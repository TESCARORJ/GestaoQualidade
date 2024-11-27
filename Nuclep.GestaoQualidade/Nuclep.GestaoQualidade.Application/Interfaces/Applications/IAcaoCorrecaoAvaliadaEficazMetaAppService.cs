using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IAcaoCorrecaoAvaliadaEficazMetaAppService : IDisposable
    {
        Task<AcaoCorrecaoAvaliadaEficazMetaResponseDTO> AddAsync(AcaoCorrecaoAvaliadaEficazMetaRequestDTO request);
        Task<AcaoCorrecaoAvaliadaEficazMetaResponseDTO> UpdateAsync(long id, AcaoCorrecaoAvaliadaEficazMetaRequestDTO request);
        Task<AcaoCorrecaoAvaliadaEficazMetaResponseDTO> DeleteAsync(long id);
        Task<AcaoCorrecaoAvaliadaEficazMetaResponseDTO> GetByIdAsync(long id);
        Task<List<AcaoCorrecaoAvaliadaEficazMetaResponseDTO>> GetAllAsync();
        Task<List<AcaoCorrecaoAvaliadaEficazMetaResponseDTO>> GetAllAtivosAsync();
    }
    
}
