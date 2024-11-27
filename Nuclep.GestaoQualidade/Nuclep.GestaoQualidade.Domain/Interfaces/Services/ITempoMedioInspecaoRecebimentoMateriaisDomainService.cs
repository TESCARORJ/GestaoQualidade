using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ITempoMedioInspecaoRecebimentoMateriaisDomainService : IDisposable
    {
        Task<TempoMedioInspecaoRecebimentoMateriais> AddAsync(TempoMedioInspecaoRecebimentoMateriais entity);
        Task<TempoMedioInspecaoRecebimentoMateriais> UpdateAsync(TempoMedioInspecaoRecebimentoMateriais entity);
        Task<TempoMedioInspecaoRecebimentoMateriais> DeleteAsync(long id);
        Task<TempoMedioInspecaoRecebimentoMateriais> GetByIdAsync(long id);
        Task<List<TempoMedioInspecaoRecebimentoMateriais>> GetAllAsync();
        Task<List<TempoMedioInspecaoRecebimentoMateriais>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoMedioInspecaoRecebimentoMateriais>> GetAllAtivosAsync();
    }
}