using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IDefeitoSoldagemMetaRepository : IBaseRepository<DefeitoSoldagemMeta, long>
    {
        Task<DefeitoSoldagemMeta?> GetOneAsync(Expression<Func<DefeitoSoldagemMeta, bool>> where);
        Task<DefeitoSoldagemMeta?> GetByIdAsync(long id);
        Task<List<DefeitoSoldagemMeta>> GetAllAsync();
        Task<List<DefeitoSoldagemMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<DefeitoSoldagemMeta>> GetAllAtivosAsync();
    }
}
