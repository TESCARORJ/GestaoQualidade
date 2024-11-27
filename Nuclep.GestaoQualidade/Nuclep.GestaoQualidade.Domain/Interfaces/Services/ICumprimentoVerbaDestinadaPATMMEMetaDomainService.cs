using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ICumprimentoVerbaDestinadaPATMMEMetaDomainService : IDisposable
    {
        Task<CumprimentoVerbaDestinadaPATMMEMeta> AddAsync(CumprimentoVerbaDestinadaPATMMEMeta entity);
        Task<CumprimentoVerbaDestinadaPATMMEMeta> UpdateAsync(CumprimentoVerbaDestinadaPATMMEMeta entity);
        Task<CumprimentoVerbaDestinadaPATMMEMeta> DeleteAsync(long id);
        Task<CumprimentoVerbaDestinadaPATMMEMeta> GetByIdAsync(long id);
        Task<List<CumprimentoVerbaDestinadaPATMMEMeta>> GetAllAsync();
        Task<List<CumprimentoVerbaDestinadaPATMMEMeta>> GetAllAtivosAsync();
    }
}