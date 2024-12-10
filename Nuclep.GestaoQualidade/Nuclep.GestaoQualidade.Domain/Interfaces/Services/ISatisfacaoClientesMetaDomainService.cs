using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ISatisfacaoClientesMetaDomainService : IDisposable
    {
        Task<SatisfacaoClientesMeta> AddAsync(SatisfacaoClientesMeta entity);
        Task<SatisfacaoClientesMeta> UpdateAsync(SatisfacaoClientesMeta entity);
        Task<SatisfacaoClientesMeta> DeleteAsync(long id);
        Task<SatisfacaoClientesMeta> GetByIdAsync(long id);
        Task<List<SatisfacaoClientesMeta>> GetAllAsync();
        Task<List<SatisfacaoClientesMeta>> GetAllAtivosAsync(); 
    }
}