using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ICumprimentoEtapasPACDentroPrazoMetaRepository : IBaseRepository<CumprimentoEtapasPACDentroPrazoMeta, long>
    {
        Task<CumprimentoEtapasPACDentroPrazoMeta?> GetOneAsync(Expression<Func<CumprimentoEtapasPACDentroPrazoMeta, bool>> where);
        Task<CumprimentoEtapasPACDentroPrazoMeta?> GetByIdAsync(long id);
        Task<List<CumprimentoEtapasPACDentroPrazoMeta>> GetAllAsync();
        Task<List<CumprimentoEtapasPACDentroPrazoMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<CumprimentoEtapasPACDentroPrazoMeta>> GetAllAtivosAsync();
    }
}
