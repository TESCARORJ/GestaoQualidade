using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IRetrabalhoDocumentosDomainService : IDisposable
    {
        Task<RetrabalhoDocumentos> AddAsync(RetrabalhoDocumentos entity);
        Task<RetrabalhoDocumentos> UpdateAsync(RetrabalhoDocumentos entity);
        Task<RetrabalhoDocumentos> DeleteAsync(long id);
        Task<RetrabalhoDocumentos> GetByIdAsync(long id);
        Task<List<RetrabalhoDocumentos>> GetAllAsync(); 
        Task<List<RetrabalhoDocumentos>> GetAllUsarioLogadoAsync(long usuarioLogadoId); 
        Task<List<RetrabalhoDocumentos>> GetAllAtivosAsync();
    }
}