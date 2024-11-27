using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ITempoMedioInspecaoRecebimentoMateriaisMetaDomainService : IDisposable
    {
        Task<TempoMedioInspecaoRecebimentoMateriaisMeta> AddAsync(TempoMedioInspecaoRecebimentoMateriaisMeta entity);
        Task<TempoMedioInspecaoRecebimentoMateriaisMeta> UpdateAsync(TempoMedioInspecaoRecebimentoMateriaisMeta entity);
        Task<TempoMedioInspecaoRecebimentoMateriaisMeta> DeleteAsync(long id);
        Task<TempoMedioInspecaoRecebimentoMateriaisMeta> GetByIdAsync(long id);
        Task<List<TempoMedioInspecaoRecebimentoMateriaisMeta>> GetAllAsync();
        Task<List<TempoMedioInspecaoRecebimentoMateriaisMeta>> GetAllAtivosAsync();
    }
}