using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ITempoReparoEquipamentosProgramadosObrasMetaAppService : IDisposable
    {
        Task<TempoReparoEquipamentosProgramadosObrasMetaResponseDTO> AddAsync(TempoReparoEquipamentosProgramadosObrasMetaRequestDTO request);
        Task<TempoReparoEquipamentosProgramadosObrasMetaResponseDTO> UpdateAsync(long id, TempoReparoEquipamentosProgramadosObrasMetaRequestDTO request);
        Task<TempoReparoEquipamentosProgramadosObrasMetaResponseDTO> DeleteAsync(long id);
        Task<TempoReparoEquipamentosProgramadosObrasMetaResponseDTO> GetByIdAsync(long id);
        Task<List<TempoReparoEquipamentosProgramadosObrasMetaResponseDTO>> GetAllAsync();
        Task<List<TempoReparoEquipamentosProgramadosObrasMetaResponseDTO>> GetAllAtivosAsync();
    }

}
