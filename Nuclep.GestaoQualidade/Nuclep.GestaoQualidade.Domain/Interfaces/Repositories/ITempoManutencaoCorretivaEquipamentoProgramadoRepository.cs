using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ITempoManutencaoCorretivaEquipamentoProgramadoRepository : IBaseRepository<TempoManutencaoCorretivaEquipamentoProgramado, long>
    {
        Task<TempoManutencaoCorretivaEquipamentoProgramado?> GetOneAsync(Expression<Func<TempoManutencaoCorretivaEquipamentoProgramado, bool>> where);
        Task<TempoManutencaoCorretivaEquipamentoProgramado?> GetByIdAsync(long id);
        Task<List<TempoManutencaoCorretivaEquipamentoProgramado>> GetAllAsync();
        Task<List<TempoManutencaoCorretivaEquipamentoProgramado>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoManutencaoCorretivaEquipamentoProgramado>> GetAllAtivosAsync();
    }
}
