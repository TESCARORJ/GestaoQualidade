using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ISatisfacaoUsuarioMetaDomainService : IDisposable
    {
        Task<SatisfacaoUsuarioMeta> AddAsync(SatisfacaoUsuarioMeta entity);
        Task<SatisfacaoUsuarioMeta> UpdateAsync(SatisfacaoUsuarioMeta entity);
        Task<SatisfacaoUsuarioMeta> DeleteAsync(long id);
        Task<SatisfacaoUsuarioMeta> GetByIdAsync(long id);
        Task<List<SatisfacaoUsuarioMeta>> GetAllAsync();
        Task<List<SatisfacaoUsuarioMeta>> GetAllAtivosAsync();
    }
}