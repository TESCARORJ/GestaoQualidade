using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IRespostaAreasPrazoOriginalDomainService : IDisposable
    {
        Task<RespostaAreasPrazoOriginal> AddAsync(RespostaAreasPrazoOriginal entity);
        Task<RespostaAreasPrazoOriginal> UpdateAsync(RespostaAreasPrazoOriginal entity);
        Task<RespostaAreasPrazoOriginal> DeleteAsync(long id);
        Task<RespostaAreasPrazoOriginal> GetByIdAsync(long id);
        Task<List<RespostaAreasPrazoOriginal>> GetAllAsync();
        Task<List<RespostaAreasPrazoOriginal>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<RespostaAreasPrazoOriginal>> GetAllAtivosAsync();
    }
}