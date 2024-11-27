using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ITempoReparoEquipamentosProgramadosObrasMetaDomainService : IDisposable
    {
        Task<TempoReparoEquipamentosProgramadosObrasMeta> AddAsync(TempoReparoEquipamentosProgramadosObrasMeta entity);
        Task<TempoReparoEquipamentosProgramadosObrasMeta> UpdateAsync(TempoReparoEquipamentosProgramadosObrasMeta entity);
        Task<TempoReparoEquipamentosProgramadosObrasMeta> DeleteAsync(long id);
        Task<TempoReparoEquipamentosProgramadosObrasMeta> GetByIdAsync(long id);
        Task<List<TempoReparoEquipamentosProgramadosObrasMeta>> GetAllAsync();
        Task<List<TempoReparoEquipamentosProgramadosObrasMeta>> GetAllAtivosAsync();
    }
}