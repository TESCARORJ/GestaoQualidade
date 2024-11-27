using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ITaxaConformidadeDocumentosQualidadeDomainService : IDisposable
    {
        Task<TaxaConformidadeDocumentosQualidade> AddAsync(TaxaConformidadeDocumentosQualidade entity);
        Task<TaxaConformidadeDocumentosQualidade> UpdateAsync(TaxaConformidadeDocumentosQualidade entity);
        Task<TaxaConformidadeDocumentosQualidade> DeleteAsync(long id);
        Task<TaxaConformidadeDocumentosQualidade> GetByIdAsync(long id);
        Task<List<TaxaConformidadeDocumentosQualidade>> GetAllAsync();
        Task<List<TaxaConformidadeDocumentosQualidade>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TaxaConformidadeDocumentosQualidade>> GetAllAtivosAsync();
    }
}