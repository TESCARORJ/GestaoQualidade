using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IDefeitoSoldagemMetaAppService : IDisposable
    {
        Task<DefeitoSoldagemMetaResponseDTO> AddAsync(DefeitoSoldagemMetaRequestDTO request);
        Task<DefeitoSoldagemMetaResponseDTO> UpdateAsync(long id, DefeitoSoldagemMetaRequestDTO request);
        Task<DefeitoSoldagemMetaResponseDTO> DeleteAsync(long id);
        Task<DefeitoSoldagemMetaResponseDTO> GetByIdAsync(long id);
        Task<List<DefeitoSoldagemMetaResponseDTO>> GetAllAsync();
        Task<List<DefeitoSoldagemMetaResponseDTO>> GetAllAtivosAsync();
    }

}
