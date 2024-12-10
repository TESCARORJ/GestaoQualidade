using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface INaoConformidadeMetaAppService : IDisposable
    {
        Task<NaoConformidadeMetaResponseDTO> AddAsync(NaoConformidadeMetaRequestDTO request);
        Task<NaoConformidadeMetaResponseDTO> UpdateAsync(long id, NaoConformidadeMetaRequestDTO request);
        Task<NaoConformidadeMetaResponseDTO> DeleteAsync(long id);
        Task<NaoConformidadeMetaResponseDTO> GetByIdAsync(long id);
        Task<List<NaoConformidadeMetaResponseDTO>> GetAllAsync();
        Task<List<NaoConformidadeMetaResponseDTO>> GetAllAtivosAsync();
    }

}
