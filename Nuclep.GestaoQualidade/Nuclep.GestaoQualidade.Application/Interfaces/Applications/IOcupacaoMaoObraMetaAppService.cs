using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IOcupacaoMaoObraMetaAppService : IDisposable
    {
        Task<OcupacaoMaoObraMetaResponseDTO> AddAsync(OcupacaoMaoObraMetaRequestDTO request);
        Task<OcupacaoMaoObraMetaResponseDTO> UpdateAsync(long id, OcupacaoMaoObraMetaRequestDTO request);
        Task<OcupacaoMaoObraMetaResponseDTO> DeleteAsync(long id);
        Task<OcupacaoMaoObraMetaResponseDTO> GetByIdAsync(long id);
        Task<List<OcupacaoMaoObraMetaResponseDTO>> GetAllAsync();
        Task<List<OcupacaoMaoObraMetaResponseDTO>> GetAllAtivosAsync();
    }

}
