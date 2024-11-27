using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ICumprimentoVerbaDestinadaPATMMEMetaAppService : IDisposable
    {
        Task<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO> AddAsync(CumprimentoVerbaDestinadaPATMMEMetaRequestDTO request);
        Task<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO> UpdateAsync(long id, CumprimentoVerbaDestinadaPATMMEMetaRequestDTO request);
        Task<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO> DeleteAsync(long id);
        Task<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO> GetByIdAsync(long id);
        Task<List<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>> GetAllAsync();
        Task<List<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>> GetAllAtivosAsync();
    }
    
}
