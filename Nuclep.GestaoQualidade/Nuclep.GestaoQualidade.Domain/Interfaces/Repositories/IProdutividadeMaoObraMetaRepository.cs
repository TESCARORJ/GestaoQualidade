using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IProdutividadeMaoObraMetaRepository : IBaseRepository<ProdutividadeMaoObraMeta, long>
    {
        Task<ProdutividadeMaoObraMeta?> GetOneAsync(Expression<Func<ProdutividadeMaoObraMeta, bool>> where);
        Task<ProdutividadeMaoObraMeta?> GetByIdAsync(long id);
        Task<List<ProdutividadeMaoObraMeta>> GetAllAsync();
        Task<List<ProdutividadeMaoObraMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<ProdutividadeMaoObraMeta>> GetAllAtivosAsync();
    }
}
