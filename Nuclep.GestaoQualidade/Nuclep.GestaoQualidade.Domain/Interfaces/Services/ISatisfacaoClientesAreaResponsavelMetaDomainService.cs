using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ISatisfacaoClientesAreaResponsavelMetaDomainService : IDisposable
    {
        Task<SatisfacaoClientesAreaResponsavelMeta> AddAsync(SatisfacaoClientesAreaResponsavelMeta entity);
        Task<SatisfacaoClientesAreaResponsavelMeta> UpdateAsync(SatisfacaoClientesAreaResponsavelMeta entity);
        Task<SatisfacaoClientesAreaResponsavelMeta> DeleteAsync(long id);
        Task<SatisfacaoClientesAreaResponsavelMeta> GetByIdAsync(long id);
        Task<List<SatisfacaoClientesAreaResponsavelMeta>> GetAllAsync();
        Task<List<SatisfacaoClientesAreaResponsavelMeta>> GetAllAtivosAsync();
    }
}