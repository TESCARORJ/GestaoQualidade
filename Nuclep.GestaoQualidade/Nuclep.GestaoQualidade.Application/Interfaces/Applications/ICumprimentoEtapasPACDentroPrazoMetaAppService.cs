using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ICumprimentoEtapasPACDentroPrazoMetaAppService : IDisposable
    {
        Task<CumprimentoEtapasPACDentroPrazoMetaResponseDTO> AddAsync(CumprimentoEtapasPACDentroPrazoMetaRequestDTO request);
        Task<CumprimentoEtapasPACDentroPrazoMetaResponseDTO> UpdateAsync(long id, CumprimentoEtapasPACDentroPrazoMetaRequestDTO request);
        Task<CumprimentoEtapasPACDentroPrazoMetaResponseDTO> DeleteAsync(long id);
        Task<CumprimentoEtapasPACDentroPrazoMetaResponseDTO> GetByIdAsync(long id);
        Task<List<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>> GetAllAsync();
        Task<List<CumprimentoEtapasPACDentroPrazoMetaResponseDTO>> GetAllAtivosAsync();
    }
    
}
