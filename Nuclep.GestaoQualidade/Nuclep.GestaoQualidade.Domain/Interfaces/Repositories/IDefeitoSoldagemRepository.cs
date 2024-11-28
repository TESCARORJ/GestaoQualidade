using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IDefeitoSoldagemRepository : IBaseRepository<DefeitoSoldagem, long>
    {
        Task<DefeitoSoldagem?> GetOneAsync(Expression<Func<DefeitoSoldagem, bool>> where);
        Task<DefeitoSoldagem?> GetByIdAsync(long id);
        Task<List<DefeitoSoldagem>> GetAllAsync();
        Task<List<DefeitoSoldagem>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<DefeitoSoldagem>> GetLocalidadeUsarioLogadoAsync(long usuarioLogadoId, long localidadeId);
        Task<List<DefeitoSoldagem>> GetAllAtivosAsync();
    }
}
