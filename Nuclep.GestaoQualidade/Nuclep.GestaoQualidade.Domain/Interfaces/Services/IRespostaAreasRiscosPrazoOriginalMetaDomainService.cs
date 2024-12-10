using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IRespostaAreasRiscosPrazoOriginalMetaDomainService : IDisposable
    {
        Task<RespostaAreasRiscosPrazoOriginalMeta> AddAsync(RespostaAreasRiscosPrazoOriginalMeta entity);
        Task<RespostaAreasRiscosPrazoOriginalMeta> UpdateAsync(RespostaAreasRiscosPrazoOriginalMeta entity);
        Task<RespostaAreasRiscosPrazoOriginalMeta> DeleteAsync(long id);
        Task<RespostaAreasRiscosPrazoOriginalMeta> GetByIdAsync(long id);
        Task<List<RespostaAreasRiscosPrazoOriginalMeta>> GetAllAsync();
        Task<List<RespostaAreasRiscosPrazoOriginalMeta>> GetAllAtivosAsync();
    }
}