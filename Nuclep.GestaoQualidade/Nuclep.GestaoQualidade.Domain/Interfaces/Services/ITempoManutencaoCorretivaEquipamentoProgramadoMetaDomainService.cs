using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ITempoManutencaoCorretivaEquipamentoProgramadoMetaDomainService : IDisposable
    {
        Task<TempoManutencaoCorretivaEquipamentoProgramadoMeta> AddAsync(TempoManutencaoCorretivaEquipamentoProgramadoMeta entity);
        Task<TempoManutencaoCorretivaEquipamentoProgramadoMeta> UpdateAsync(TempoManutencaoCorretivaEquipamentoProgramadoMeta entity);
        Task<TempoManutencaoCorretivaEquipamentoProgramadoMeta> DeleteAsync(long id);
        Task<TempoManutencaoCorretivaEquipamentoProgramadoMeta> GetByIdAsync(long id);
        Task<List<TempoManutencaoCorretivaEquipamentoProgramadoMeta>> GetAllAsync();
        Task<List<TempoManutencaoCorretivaEquipamentoProgramadoMeta>> GetAllAtivosAsync();
    }
}