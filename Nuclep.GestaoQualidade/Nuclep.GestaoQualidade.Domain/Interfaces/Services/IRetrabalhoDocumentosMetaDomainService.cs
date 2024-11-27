using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IRetrabalhoDocumentosMetaDomainService : IDisposable
    {
        Task<RetrabalhoDocumentosMeta> AddAsync(RetrabalhoDocumentosMeta entity);
        Task<RetrabalhoDocumentosMeta> UpdateAsync(RetrabalhoDocumentosMeta entity);
        Task<RetrabalhoDocumentosMeta> DeleteAsync(long id);
        Task<RetrabalhoDocumentosMeta> GetByIdAsync(long id);
        Task<List<RetrabalhoDocumentosMeta>> GetAllAsync();
        Task<List<RetrabalhoDocumentosMeta>> GetAllAtivosAsync();
    }
}