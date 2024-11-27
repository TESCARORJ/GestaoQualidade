using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IAutoavaliacaoGerencialSGQMetaAppService : IDisposable
    {
        Task<AutoavaliacaoGerencialSGQMetaResponseDTO> AddAsync(AutoavaliacaoGerencialSGQMetaRequestDTO request);
        Task<AutoavaliacaoGerencialSGQMetaResponseDTO> UpdateAsync(long id, AutoavaliacaoGerencialSGQMetaRequestDTO request);
        Task<AutoavaliacaoGerencialSGQMetaResponseDTO> DeleteAsync(long id);
        Task<AutoavaliacaoGerencialSGQMetaResponseDTO> GetByIdAsync(long id);
        Task<List<AutoavaliacaoGerencialSGQMetaResponseDTO>> GetAllAsync();
        Task<List<AutoavaliacaoGerencialSGQMetaResponseDTO>> GetAllAtivosAsync();
    }
    
}
