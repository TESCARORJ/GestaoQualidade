using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IProdutividadeMaoObraMetaAppService : IDisposable
    {
        Task<ProdutividadeMaoObraMetaResponseDTO> AddAsync(ProdutividadeMaoObraMetaRequestDTO request);
        Task<ProdutividadeMaoObraMetaResponseDTO> UpdateAsync(long id, ProdutividadeMaoObraMetaRequestDTO request);
        Task<ProdutividadeMaoObraMetaResponseDTO> DeleteAsync(long id);
        Task<ProdutividadeMaoObraMetaResponseDTO> GetByIdAsync(long id);
        Task<List<ProdutividadeMaoObraMetaResponseDTO>> GetAllAsync();
        Task<List<ProdutividadeMaoObraMetaResponseDTO>> GetAllAtivosAsync();
    }

}
