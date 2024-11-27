using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ITaxaConformidadeDocumentosQualidadeMetaRepository : IBaseRepository<TaxaConformidadeDocumentosQualidadeMeta, long>
    {
        Task<TaxaConformidadeDocumentosQualidadeMeta?> GetOneAsync(Expression<Func<TaxaConformidadeDocumentosQualidadeMeta, bool>> where);
        Task<TaxaConformidadeDocumentosQualidadeMeta?> GetByIdAsync(long id);
        Task<List<TaxaConformidadeDocumentosQualidadeMeta>> GetAllAsync();
        Task<List<TaxaConformidadeDocumentosQualidadeMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TaxaConformidadeDocumentosQualidadeMeta>> GetAllAtivosAsync();
    }
}
