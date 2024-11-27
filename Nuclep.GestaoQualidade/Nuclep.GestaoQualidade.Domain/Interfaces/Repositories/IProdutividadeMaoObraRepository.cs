using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IProdutividadeMaoObraRepository : IBaseRepository<ProdutividadeMaoObra, long>
    {
        Task<ProdutividadeMaoObra?> GetOneAsync(Expression<Func<ProdutividadeMaoObra, bool>> where);
        Task<ProdutividadeMaoObra?> GetByIdAsync(long id);
        Task<List<ProdutividadeMaoObra>> GetAllAsync();
        Task<List<ProdutividadeMaoObra>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<ProdutividadeMaoObra>> GetAllAtivosAsync();
    }
}
