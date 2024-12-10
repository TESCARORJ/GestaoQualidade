using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ISatisfacaoClientesMetaAppService : IDisposable
    {
        Task<SatisfacaoClientesMetaResponseDTO> AddAsync(SatisfacaoClientesMetaRequestDTO request);
        Task<SatisfacaoClientesMetaResponseDTO> UpdateAsync(long id, SatisfacaoClientesMetaRequestDTO request);
        Task<SatisfacaoClientesMetaResponseDTO> DeleteAsync(long id);
        Task<SatisfacaoClientesMetaResponseDTO> GetByIdAsync(long id);
        Task<List<SatisfacaoClientesMetaResponseDTO>> GetAllAsync();
        Task<List<SatisfacaoClientesMetaResponseDTO>> GetAllAtivosAsync();
    }

}
