using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ITempoManutencaoCorretivaEquipamentoProgramadoMetaRepository : IBaseRepository<TempoManutencaoCorretivaEquipamentoProgramadoMeta, long>
    {
        Task<TempoManutencaoCorretivaEquipamentoProgramadoMeta?> GetOneAsync(Expression<Func<TempoManutencaoCorretivaEquipamentoProgramadoMeta, bool>> where);
        Task<TempoManutencaoCorretivaEquipamentoProgramadoMeta?> GetByIdAsync(long id);
        Task<List<TempoManutencaoCorretivaEquipamentoProgramadoMeta>> GetAllAsync();
        Task<List<TempoManutencaoCorretivaEquipamentoProgramadoMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoManutencaoCorretivaEquipamentoProgramadoMeta>> GetAllAtivosAsync();
    }
}
