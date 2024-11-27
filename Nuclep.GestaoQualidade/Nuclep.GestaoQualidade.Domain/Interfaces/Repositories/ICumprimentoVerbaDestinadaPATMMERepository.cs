using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ICumprimentoVerbaDestinadaPATMMERepository : IBaseRepository<CumprimentoVerbaDestinadaPATMME, long>
    {
        Task<CumprimentoVerbaDestinadaPATMME?> GetOneAsync(Expression<Func<CumprimentoVerbaDestinadaPATMME, bool>> where);
        Task<CumprimentoVerbaDestinadaPATMME?> GetByIdAsync(long id);
        Task<List<CumprimentoVerbaDestinadaPATMME>> GetAllAsync();
        Task<List<CumprimentoVerbaDestinadaPATMME>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<CumprimentoVerbaDestinadaPATMME>> GetAllAtivosAsync();
    }
}
