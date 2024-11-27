using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ITaxaConformidadeDocumentosQualidadeRepository : IBaseRepository<TaxaConformidadeDocumentosQualidade, long>
    {
        Task<TaxaConformidadeDocumentosQualidade?> GetOneAsync(Expression<Func<TaxaConformidadeDocumentosQualidade, bool>> where);
        Task<TaxaConformidadeDocumentosQualidade?> GetByIdAsync(long id);
        Task<List<TaxaConformidadeDocumentosQualidade>> GetAllAsync();
        Task<List<TaxaConformidadeDocumentosQualidade>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TaxaConformidadeDocumentosQualidade>> GetAllAtivosAsync();
    }
}
