using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IDuracaoProcessoLicitacaoMetaRepository : IBaseRepository<DuracaoProcessoLicitacaoMeta, long>
    {
        Task<DuracaoProcessoLicitacaoMeta?> GetOneAsync(Expression<Func<DuracaoProcessoLicitacaoMeta, bool>> where);
        Task<DuracaoProcessoLicitacaoMeta?> GetByIdAsync(long id);
        Task<List<DuracaoProcessoLicitacaoMeta>> GetAllAsync();
        Task<List<DuracaoProcessoLicitacaoMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<DuracaoProcessoLicitacaoMeta>> GetAllAtivosAsync();
    }
}
