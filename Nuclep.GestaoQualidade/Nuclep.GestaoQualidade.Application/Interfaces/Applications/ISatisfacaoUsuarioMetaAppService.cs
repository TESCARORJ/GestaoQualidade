using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ISatisfacaoUsuarioMetaAppService : IDisposable
    {
        Task<SatisfacaoUsuarioMetaResponseDTO> AddAsync(SatisfacaoUsuarioMetaRequestDTO request);
        Task<SatisfacaoUsuarioMetaResponseDTO> UpdateAsync(long id, SatisfacaoUsuarioMetaRequestDTO request);
        Task<SatisfacaoUsuarioMetaResponseDTO> DeleteAsync(long id);
        Task<SatisfacaoUsuarioMetaResponseDTO> GetByIdAsync(long id);
        Task<List<SatisfacaoUsuarioMetaResponseDTO>> GetAllAsync();
        Task<List<SatisfacaoUsuarioMetaResponseDTO>> GetAllAtivosAsync();
    }

}
