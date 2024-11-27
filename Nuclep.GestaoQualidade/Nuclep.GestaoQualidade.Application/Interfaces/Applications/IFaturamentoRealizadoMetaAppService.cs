using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IFaturamentoRealizadoMetaAppService : IDisposable
    {
        Task<FaturamentoRealizadoMetaResponseDTO> AddAsync(FaturamentoRealizadoMetaRequestDTO request);
        Task<FaturamentoRealizadoMetaResponseDTO> UpdateAsync(long id, FaturamentoRealizadoMetaRequestDTO request);
        Task<FaturamentoRealizadoMetaResponseDTO> DeleteAsync(long id);
        Task<FaturamentoRealizadoMetaResponseDTO> GetByIdAsync(long id);
        Task<List<FaturamentoRealizadoMetaResponseDTO>> GetAllAsync();
        Task<List<FaturamentoRealizadoMetaResponseDTO>> GetAllAtivosAsync();
    }
    
}
