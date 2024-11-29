using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IRejeicaoMateriaisMetaAppService : IDisposable
    {
        Task<RejeicaoMateriaisMetaResponseDTO> AddAsync(RejeicaoMateriaisMetaRequestDTO request);
        Task<RejeicaoMateriaisMetaResponseDTO> UpdateAsync(long id, RejeicaoMateriaisMetaRequestDTO request);
        Task<RejeicaoMateriaisMetaResponseDTO> DeleteAsync(long id);
        Task<RejeicaoMateriaisMetaResponseDTO> GetByIdAsync(long id);
        Task<List<RejeicaoMateriaisMetaResponseDTO>> GetAllAsync();
        Task<List<RejeicaoMateriaisMetaResponseDTO>> GetAllAtivosAsync();
    }
    
}
