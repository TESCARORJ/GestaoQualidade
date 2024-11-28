using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IEficaciaTreinamentoMetaAppService : IDisposable
    {
        Task<EficaciaTreinamentoMetaResponseDTO> AddAsync(EficaciaTreinamentoMetaRequestDTO request);
        Task<EficaciaTreinamentoMetaResponseDTO> UpdateAsync(long id, EficaciaTreinamentoMetaRequestDTO request);
        Task<EficaciaTreinamentoMetaResponseDTO> DeleteAsync(long id);
        Task<EficaciaTreinamentoMetaResponseDTO> GetByIdAsync(long id);
        Task<List<EficaciaTreinamentoMetaResponseDTO>> GetAllAsync();
        Task<List<EficaciaTreinamentoMetaResponseDTO>> GetAllAtivosAsync();
    }
    
}
