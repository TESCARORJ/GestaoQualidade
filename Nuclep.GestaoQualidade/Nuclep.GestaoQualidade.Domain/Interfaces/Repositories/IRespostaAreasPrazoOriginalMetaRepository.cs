using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IRespostaAreasPrazoOriginalMetaRepository : IBaseRepository<RespostaAreasPrazoOriginalMeta, long>
    {
        Task<RespostaAreasPrazoOriginalMeta?> GetOneAsync(Expression<Func<RespostaAreasPrazoOriginalMeta, bool>> where);
        Task<RespostaAreasPrazoOriginalMeta?> GetByIdAsync(long id);
        Task<List<RespostaAreasPrazoOriginalMeta>> GetAllAsync();
        Task<List<RespostaAreasPrazoOriginalMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<RespostaAreasPrazoOriginalMeta>> GetAllAtivosAsync();
    }
}
