using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IOcupacaoMaoObraRepository : IBaseRepository<OcupacaoMaoObra, long>
    {
        Task<OcupacaoMaoObra?> GetOneAsync(Expression<Func<OcupacaoMaoObra, bool>> where);
        Task<OcupacaoMaoObra?> GetByIdAsync(long id);
        Task<List<OcupacaoMaoObra>> GetAllAsync();
        Task<List<OcupacaoMaoObra>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<OcupacaoMaoObra>> GetAllAtivosAsync();
    }
}
