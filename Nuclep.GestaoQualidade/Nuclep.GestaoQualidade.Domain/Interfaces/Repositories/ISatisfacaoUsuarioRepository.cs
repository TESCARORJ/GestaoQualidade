using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ISatisfacaoUsuarioRepository : IBaseRepository<SatisfacaoUsuario, long>
    {
        Task<SatisfacaoUsuario?> GetOneAsync(Expression<Func<SatisfacaoUsuario, bool>> where);
        Task<SatisfacaoUsuario?> GetByIdAsync(long id);
        Task<List<SatisfacaoUsuario>> GetAllAsync();
        Task<List<SatisfacaoUsuario>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<SatisfacaoUsuario>> GetAllAtivosAsync();
    }
}
