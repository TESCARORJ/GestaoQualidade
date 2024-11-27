using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IEventosAtrasoDomainService : IDisposable
    {
        Task<EventosAtraso> AddAsync(EventosAtraso entity);
        Task<EventosAtraso> UpdateAsync(EventosAtraso entity);
        Task<EventosAtraso> DeleteAsync(long id);
        Task<EventosAtraso> GetByIdAsync(long id);
        Task<List<EventosAtraso>> GetAllAsync();
        Task<List<EventosAtraso>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<EventosAtraso>> GetAllAtivosAsync();
    }
}