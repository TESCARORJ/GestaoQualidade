using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IAderenciaProgramacaoMensalMetaRepository : IBaseRepository<AderenciaProgramacaoMensalMeta, long>
    {
        Task<AderenciaProgramacaoMensalMeta?> GetOneAsync(Expression<Func<AderenciaProgramacaoMensalMeta, bool>> where);
        Task<AderenciaProgramacaoMensalMeta?> GetByIdAsync(long id);
        Task<List<AderenciaProgramacaoMensalMeta>> GetAllAsync();
        Task<List<AderenciaProgramacaoMensalMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<AderenciaProgramacaoMensalMeta>> GetAllAtivosAsync();
    }
}
