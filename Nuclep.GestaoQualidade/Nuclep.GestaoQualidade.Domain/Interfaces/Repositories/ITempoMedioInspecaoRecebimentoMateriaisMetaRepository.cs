using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ITempoMedioInspecaoRecebimentoMateriaisMetaRepository : IBaseRepository<TempoMedioInspecaoRecebimentoMateriaisMeta, long>
    {
        Task<TempoMedioInspecaoRecebimentoMateriaisMeta?> GetOneAsync(Expression<Func<TempoMedioInspecaoRecebimentoMateriaisMeta, bool>> where);
        Task<TempoMedioInspecaoRecebimentoMateriaisMeta?> GetByIdAsync(long id);
        Task<List<TempoMedioInspecaoRecebimentoMateriaisMeta>> GetAllAsync();
        Task<List<TempoMedioInspecaoRecebimentoMateriaisMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoMedioInspecaoRecebimentoMateriaisMeta>> GetAllAtivosAsync();
    }
}
