using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IRespostaAreasPrazoOriginalMetaDomainService : IDisposable
    {
        Task<RespostaAreasPrazoOriginalMeta> AddAsync(RespostaAreasPrazoOriginalMeta entity);
        Task<RespostaAreasPrazoOriginalMeta> UpdateAsync(RespostaAreasPrazoOriginalMeta entity);
        Task<RespostaAreasPrazoOriginalMeta> DeleteAsync(long id);
        Task<RespostaAreasPrazoOriginalMeta> GetByIdAsync(long id);
        Task<List<RespostaAreasPrazoOriginalMeta>> GetAllAsync();
        Task<List<RespostaAreasPrazoOriginalMeta>> GetAllAtivosAsync();
    }
}