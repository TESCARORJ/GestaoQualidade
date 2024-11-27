using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IRetrabalhoDocumentosRepository : IBaseRepository<RetrabalhoDocumentos, long>
    {
        Task<RetrabalhoDocumentos?> GetOneAsync(Expression<Func<RetrabalhoDocumentos, bool>> where);
        Task<RetrabalhoDocumentos?> GetByIdAsync(long id);
        Task<List<RetrabalhoDocumentos>> GetAllAsync();
        Task<List<RetrabalhoDocumentos>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<RetrabalhoDocumentos>> GetAllAtivosAsync();
    }
}
