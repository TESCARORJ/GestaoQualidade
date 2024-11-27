using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IDuracaoProcessoLicitacaoRepository : IBaseRepository<DuracaoProcessoLicitacao, long>
    {
        Task<DuracaoProcessoLicitacao?> GetOneAsync(Expression<Func<DuracaoProcessoLicitacao, bool>> where);
        Task<DuracaoProcessoLicitacao?> GetByIdAsync(long id);
        Task<List<DuracaoProcessoLicitacao>> GetAllAsync();
        Task<List<DuracaoProcessoLicitacao>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<DuracaoProcessoLicitacao>> GetAllAtivosAsync();
    }
}
