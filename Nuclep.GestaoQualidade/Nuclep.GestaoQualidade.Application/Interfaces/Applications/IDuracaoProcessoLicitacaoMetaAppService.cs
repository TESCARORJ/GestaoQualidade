using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IDuracaoProcessoLicitacaoMetaAppService : IDisposable
    {
        Task<DuracaoProcessoLicitacaoMetaResponseDTO> AddAsync(DuracaoProcessoLicitacaoMetaRequestDTO request);
        Task<DuracaoProcessoLicitacaoMetaResponseDTO> UpdateAsync(long id, DuracaoProcessoLicitacaoMetaRequestDTO request);
        Task<DuracaoProcessoLicitacaoMetaResponseDTO> DeleteAsync(long id);
        Task<DuracaoProcessoLicitacaoMetaResponseDTO> GetByIdAsync(long id);
        Task<List<DuracaoProcessoLicitacaoMetaResponseDTO>> GetAllAsync();
        Task<List<DuracaoProcessoLicitacaoMetaResponseDTO>> GetAllAtivosAsync();
    }
    
}
