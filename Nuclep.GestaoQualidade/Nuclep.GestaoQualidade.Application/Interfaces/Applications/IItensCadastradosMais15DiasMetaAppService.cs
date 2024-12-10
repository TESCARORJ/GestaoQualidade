using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IItensCadastradosMais15DiasMetaAppService : IDisposable
    {
        Task<ItensCadastradosMais15DiasMetaResponseDTO> AddAsync(ItensCadastradosMais15DiasMetaRequestDTO request);
        Task<ItensCadastradosMais15DiasMetaResponseDTO> UpdateAsync(long id, ItensCadastradosMais15DiasMetaRequestDTO request);
        Task<ItensCadastradosMais15DiasMetaResponseDTO> DeleteAsync(long id);
        Task<ItensCadastradosMais15DiasMetaResponseDTO> GetByIdAsync(long id);
        Task<List<ItensCadastradosMais15DiasMetaResponseDTO>> GetAllAsync();
        Task<List<ItensCadastradosMais15DiasMetaResponseDTO>> GetAllAtivosAsync();
    }

}
