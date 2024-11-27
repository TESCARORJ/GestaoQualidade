using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IAderenciaProgramacaoMensalMetaAppService : IDisposable
    {
        Task<AderenciaProgramacaoMensalMetaResponseDTO> AddAsync(AderenciaProgramacaoMensalMetaRequestDTO request);
        Task<AderenciaProgramacaoMensalMetaResponseDTO> UpdateAsync(long id, AderenciaProgramacaoMensalMetaRequestDTO request);
        Task<AderenciaProgramacaoMensalMetaResponseDTO> DeleteAsync(long id);
        Task<AderenciaProgramacaoMensalMetaResponseDTO> GetByIdAsync(long id);
        Task<List<AderenciaProgramacaoMensalMetaResponseDTO>> GetAllAsync();
        Task<List<AderenciaProgramacaoMensalMetaResponseDTO>> GetAllAtivosAsync();
    }
    
}
