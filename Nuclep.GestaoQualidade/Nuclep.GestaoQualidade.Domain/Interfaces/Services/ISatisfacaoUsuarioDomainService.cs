using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ISatisfacaoUsuarioDomainService : IDisposable
    {
        Task<SatisfacaoUsuario> AddAsync(SatisfacaoUsuario entity);
        Task<SatisfacaoUsuario> UpdateAsync(SatisfacaoUsuario entity);
        Task<SatisfacaoUsuario> DeleteAsync(long id);
        Task<SatisfacaoUsuario> GetByIdAsync(long id);
        Task<List<SatisfacaoUsuario>> GetAllAsync();
        Task<List<SatisfacaoUsuario>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<SatisfacaoUsuario>> GetAllAtivosAsync();
    }
}