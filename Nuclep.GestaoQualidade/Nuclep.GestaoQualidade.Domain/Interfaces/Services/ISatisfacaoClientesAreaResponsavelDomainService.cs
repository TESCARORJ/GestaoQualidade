using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ISatisfacaoClientesAreaResponsavelDomainService : IDisposable
    {
        Task<SatisfacaoClientesAreaResponsavel> AddAsync(SatisfacaoClientesAreaResponsavel entity);
        Task<SatisfacaoClientesAreaResponsavel> UpdateAsync(SatisfacaoClientesAreaResponsavel entity);
        Task<SatisfacaoClientesAreaResponsavel> DeleteAsync(long id);
        Task<SatisfacaoClientesAreaResponsavel> GetByIdAsync(long id);
        Task<List<SatisfacaoClientesAreaResponsavel>> GetAllAsync();
        Task<List<SatisfacaoClientesAreaResponsavel>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<SatisfacaoClientesAreaResponsavel>> GetAllAtivosAsync();
    }
}