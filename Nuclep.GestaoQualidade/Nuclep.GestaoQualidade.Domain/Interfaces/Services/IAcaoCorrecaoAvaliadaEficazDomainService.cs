using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IAcaoCorrecaoAvaliadaEficazDomainService : IDisposable
    {
        Task<AcaoCorrecaoAvaliadaEficaz> AddAsync(AcaoCorrecaoAvaliadaEficaz entity);
        Task<List<AcaoCorrecaoAvaliadaEficaz>> AddListAsync(List<AcaoCorrecaoAvaliadaEficaz> entity);
        Task<AcaoCorrecaoAvaliadaEficaz> UpdateAsync(AcaoCorrecaoAvaliadaEficaz entity);
        Task<AcaoCorrecaoAvaliadaEficaz> DeleteAsync(long id);
        Task<AcaoCorrecaoAvaliadaEficaz> GetByIdAsync(long id);
        Task<List<AcaoCorrecaoAvaliadaEficaz>> GetAllAsync();
        Task<List<AcaoCorrecaoAvaliadaEficaz>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<AcaoCorrecaoAvaliadaEficaz>> GetAllAtivosAsync();
    }
}