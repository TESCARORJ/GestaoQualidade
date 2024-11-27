using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ICumprimentoEtapasPACDentroPrazoRepository : IBaseRepository<CumprimentoEtapasPACDentroPrazo, long>
    {
        Task<CumprimentoEtapasPACDentroPrazo?> GetOneAsync(Expression<Func<CumprimentoEtapasPACDentroPrazo, bool>> where);
        Task<CumprimentoEtapasPACDentroPrazo?> GetByIdAsync(long id);
        Task<List<CumprimentoEtapasPACDentroPrazo>> GetAllAsync();
        Task<List<CumprimentoEtapasPACDentroPrazo>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<CumprimentoEtapasPACDentroPrazo>> GetAllAtivosAsync();
    }
}
