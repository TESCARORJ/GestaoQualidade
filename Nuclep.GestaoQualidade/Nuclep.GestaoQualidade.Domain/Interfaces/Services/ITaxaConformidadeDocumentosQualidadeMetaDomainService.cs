using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ITaxaConformidadeDocumentosQualidadeMetaDomainService : IDisposable
    {
        Task<TaxaConformidadeDocumentosQualidadeMeta> AddAsync(TaxaConformidadeDocumentosQualidadeMeta entity);
        Task<TaxaConformidadeDocumentosQualidadeMeta> UpdateAsync(TaxaConformidadeDocumentosQualidadeMeta entity);
        Task<TaxaConformidadeDocumentosQualidadeMeta> DeleteAsync(long id);
        Task<TaxaConformidadeDocumentosQualidadeMeta> GetByIdAsync(long id);
        Task<List<TaxaConformidadeDocumentosQualidadeMeta>> GetAllAsync();
        Task<List<TaxaConformidadeDocumentosQualidadeMeta>> GetAllAtivosAsync();
    }
}