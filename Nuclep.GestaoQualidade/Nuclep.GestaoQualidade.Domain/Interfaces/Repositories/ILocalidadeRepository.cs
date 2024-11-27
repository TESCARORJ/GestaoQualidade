using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ILocalidadeRepository : IBaseRepository<Localidade, long>
    {
        Task<Localidade?> GetOneAsync(Expression<Func<Localidade, bool>> where);
        Task<Localidade?> GetByIdAsync(long id);
        Task<List<Localidade>> GetAllAsync();
        Task<List<Localidade>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<Localidade>> GetAllAtivosAsync();
    }
}
