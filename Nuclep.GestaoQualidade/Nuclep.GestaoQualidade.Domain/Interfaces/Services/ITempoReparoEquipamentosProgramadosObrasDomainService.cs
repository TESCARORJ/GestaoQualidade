using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ITempoReparoEquipamentosProgramadosObrasDomainService : IDisposable
    {
        Task<TempoReparoEquipamentosProgramadosObras> AddAsync(TempoReparoEquipamentosProgramadosObras entity);
        Task<List<TempoReparoEquipamentosProgramadosObras>> AddListAsync(List<TempoReparoEquipamentosProgramadosObras> entity);
        Task<TempoReparoEquipamentosProgramadosObras> UpdateAsync(TempoReparoEquipamentosProgramadosObras entity);
        Task<TempoReparoEquipamentosProgramadosObras> DeleteAsync(long id);
        Task<TempoReparoEquipamentosProgramadosObras> GetByIdAsync(long id);
        Task<List<TempoReparoEquipamentosProgramadosObras>> GetAllAsync();
        Task<List<TempoReparoEquipamentosProgramadosObras>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoReparoEquipamentosProgramadosObras>> GetAllAtivosAsync();
    }
}