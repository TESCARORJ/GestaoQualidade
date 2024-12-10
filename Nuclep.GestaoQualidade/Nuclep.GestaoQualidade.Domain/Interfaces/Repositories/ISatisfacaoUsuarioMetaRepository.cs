using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ISatisfacaoUsuarioMetaRepository : IBaseRepository<SatisfacaoUsuarioMeta, long>
    {
        Task<SatisfacaoUsuarioMeta?> GetOneAsync(Expression<Func<SatisfacaoUsuarioMeta, bool>> where);
        Task<SatisfacaoUsuarioMeta?> GetByIdAsync(long id);
        Task<List<SatisfacaoUsuarioMeta>> GetAllAsync();
        Task<List<SatisfacaoUsuarioMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<SatisfacaoUsuarioMeta>> GetAllAtivosAsync();
    }
}
