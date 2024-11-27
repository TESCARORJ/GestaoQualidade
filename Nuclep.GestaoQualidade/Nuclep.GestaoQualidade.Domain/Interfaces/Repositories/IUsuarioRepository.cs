using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario, long>
    {
        Task<Usuario?> GetOneAsync(Expression<Func<Usuario, bool>> where);
        Task<Usuario?> GetByIdAsync(long id);
        Task<List<Usuario>> GetAllAsync();
        Task<List<Usuario>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<Usuario>> GetAllAtivosAsync();
    }
}
