using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IOcupacaoMaoObraMetaRepository : IBaseRepository<OcupacaoMaoObraMeta, long>
    {
        Task<OcupacaoMaoObraMeta?> GetOneAsync(Expression<Func<OcupacaoMaoObraMeta, bool>> where);
        Task<OcupacaoMaoObraMeta?> GetByIdAsync(long id);
        Task<List<OcupacaoMaoObraMeta>> GetAllAsync();
        Task<List<OcupacaoMaoObraMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<OcupacaoMaoObraMeta>> GetAllAtivosAsync();
    }
}
