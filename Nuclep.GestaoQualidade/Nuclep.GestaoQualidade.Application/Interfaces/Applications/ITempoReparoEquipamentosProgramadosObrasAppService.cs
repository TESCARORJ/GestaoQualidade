using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ITempoReparoEquipamentosProgramadosObrasAppService : IDisposable
    {

        Task GararPerguntasAsync();
        Task<TempoReparoEquipamentosProgramadosObrasResponseDTO> UpdateAsync(long id, TempoReparoEquipamentosProgramadosObrasRequestDTO request);
        Task<TempoReparoEquipamentosProgramadosObrasResponseDTO> DeleteAsync(long id);
        Task<TempoReparoEquipamentosProgramadosObrasResponseDTO> GetByIdAsync(long id);
        Task<List<TempoReparoEquipamentosProgramadosObrasResponseDTO>> GetAllAsync();
        Task<List<TempoReparoEquipamentosProgramadosObrasResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<TempoReparoEquipamentosProgramadosObrasResponseDTO>> GetAllAtivosAsync();
    }
}
