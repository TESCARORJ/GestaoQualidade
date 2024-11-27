using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IRespostaAreasPrazoOriginalRepository : IBaseRepository<RespostaAreasPrazoOriginal, long>
    {
        Task<RespostaAreasPrazoOriginal?> GetOneAsync(Expression<Func<RespostaAreasPrazoOriginal, bool>> where);
        Task<RespostaAreasPrazoOriginal?> GetByIdAsync(long id);
        Task<List<RespostaAreasPrazoOriginal>> GetAllAsync();
        Task<List<RespostaAreasPrazoOriginal>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<RespostaAreasPrazoOriginal>> GetAllAtivosAsync();
    }
}
