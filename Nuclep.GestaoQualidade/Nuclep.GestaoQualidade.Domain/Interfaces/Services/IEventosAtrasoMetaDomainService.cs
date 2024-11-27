using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IEventosAtrasoMetaDomainService : IDisposable
    {
        Task<EventosAtrasoMeta> AddAsync(EventosAtrasoMeta entity);
        Task<EventosAtrasoMeta> UpdateAsync(EventosAtrasoMeta entity);
        Task<EventosAtrasoMeta> DeleteAsync(long id);
        Task<EventosAtrasoMeta> GetByIdAsync(long id);
        Task<List<EventosAtrasoMeta>> GetAllAsync();
        Task<List<EventosAtrasoMeta>> GetAllAtivosAsync();
    }
}