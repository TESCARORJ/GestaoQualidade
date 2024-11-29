using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IRejeicaoMateriaisRepository : IBaseRepository<RejeicaoMateriais, long>
    {
        Task<RejeicaoMateriais?> GetOneAsync(Expression<Func<RejeicaoMateriais, bool>> where);
        Task<RejeicaoMateriais?> GetByIdAsync(long id);
        Task<List<RejeicaoMateriais>> GetAllAsync();
        Task<List<RejeicaoMateriais>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<RejeicaoMateriais>> GetAllAtivosAsync();
    }
}
