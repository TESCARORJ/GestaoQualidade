using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IRetrabalhoDocumentosMetaRepository : IBaseRepository<RetrabalhoDocumentosMeta, long>
    {
        Task<RetrabalhoDocumentosMeta?> GetOneAsync(Expression<Func<RetrabalhoDocumentosMeta, bool>> where);
        Task<RetrabalhoDocumentosMeta?> GetByIdAsync(long id);
        Task<List<RetrabalhoDocumentosMeta>> GetAllAsync();
        Task<List<RetrabalhoDocumentosMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<RetrabalhoDocumentosMeta>> GetAllAtivosAsync();
    }
}
