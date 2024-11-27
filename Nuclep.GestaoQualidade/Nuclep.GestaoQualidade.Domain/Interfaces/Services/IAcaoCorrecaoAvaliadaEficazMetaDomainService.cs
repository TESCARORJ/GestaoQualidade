using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IAcaoCorrecaoAvaliadaEficazMetaDomainService : IDisposable
    {
        Task<AcaoCorrecaoAvaliadaEficazMeta> AddAsync(AcaoCorrecaoAvaliadaEficazMeta entity);
        Task<AcaoCorrecaoAvaliadaEficazMeta> UpdateAsync(AcaoCorrecaoAvaliadaEficazMeta entity);
        Task<AcaoCorrecaoAvaliadaEficazMeta> DeleteAsync(long id);
        Task<AcaoCorrecaoAvaliadaEficazMeta> GetByIdAsync(long id);
        Task<List<AcaoCorrecaoAvaliadaEficazMeta>> GetAllAsync();
        Task<List<AcaoCorrecaoAvaliadaEficazMeta>> GetAllAtivosAsync();
    }
}