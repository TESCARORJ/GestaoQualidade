using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ICumprimentoVerbaDestinadaPATMMEDomainService : IDisposable
    {
        Task<CumprimentoVerbaDestinadaPATMME> AddAsync(CumprimentoVerbaDestinadaPATMME entity);
        Task<List<CumprimentoVerbaDestinadaPATMME>> AddListAsync(List<CumprimentoVerbaDestinadaPATMME> entity);

        Task<CumprimentoVerbaDestinadaPATMME> UpdateAsync(CumprimentoVerbaDestinadaPATMME entity);
        Task<CumprimentoVerbaDestinadaPATMME> DeleteAsync(long id);
        Task<CumprimentoVerbaDestinadaPATMME> GetByIdAsync(long id);
        Task<List<CumprimentoVerbaDestinadaPATMME>> GetAllAsync();
        Task<List<CumprimentoVerbaDestinadaPATMME>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<CumprimentoVerbaDestinadaPATMME>> GetAllAtivosAsync();
    }
}