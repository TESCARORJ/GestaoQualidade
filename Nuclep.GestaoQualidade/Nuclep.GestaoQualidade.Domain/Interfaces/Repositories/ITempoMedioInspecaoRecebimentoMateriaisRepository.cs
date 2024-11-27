using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ITempoMedioInspecaoRecebimentoMateriaisRepository : IBaseRepository<TempoMedioInspecaoRecebimentoMateriais, long>
    {
        Task<TempoMedioInspecaoRecebimentoMateriais?> GetOneAsync(Expression<Func<TempoMedioInspecaoRecebimentoMateriais, bool>> where);
        Task<TempoMedioInspecaoRecebimentoMateriais?> GetByIdAsync(long id);
        Task<List<TempoMedioInspecaoRecebimentoMateriais>> GetAllAsync();
        Task<List<TempoMedioInspecaoRecebimentoMateriais>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoMedioInspecaoRecebimentoMateriais>> GetAllAtivosAsync();
    }
}
