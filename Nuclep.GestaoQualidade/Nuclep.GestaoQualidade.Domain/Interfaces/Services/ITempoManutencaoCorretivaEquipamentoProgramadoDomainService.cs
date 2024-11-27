using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ITempoManutencaoCorretivaEquipamentoProgramadoDomainService : IDisposable
    {
        Task<TempoManutencaoCorretivaEquipamentoProgramado> AddAsync(TempoManutencaoCorretivaEquipamentoProgramado entity);
        Task<TempoManutencaoCorretivaEquipamentoProgramado> UpdateAsync(TempoManutencaoCorretivaEquipamentoProgramado entity);
        Task<TempoManutencaoCorretivaEquipamentoProgramado> DeleteAsync(long id);
        Task<TempoManutencaoCorretivaEquipamentoProgramado> GetByIdAsync(long id);
        Task<List<TempoManutencaoCorretivaEquipamentoProgramado>> GetAllAsync();
        Task<List<TempoManutencaoCorretivaEquipamentoProgramado>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoManutencaoCorretivaEquipamentoProgramado>> GetAllAtivosAsync();
    }
}