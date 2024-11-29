using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IRejeicaoMateriaisMetaRepository : IBaseRepository<RejeicaoMateriaisMeta, long>
    {
        Task<RejeicaoMateriaisMeta?> GetOneAsync(Expression<Func<RejeicaoMateriaisMeta, bool>> where);
        Task<RejeicaoMateriaisMeta?> GetByIdAsync(long id);
        Task<List<RejeicaoMateriaisMeta>> GetAllAsync();
        Task<List<RejeicaoMateriaisMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<RejeicaoMateriaisMeta>> GetAllAtivosAsync();
    }
}
