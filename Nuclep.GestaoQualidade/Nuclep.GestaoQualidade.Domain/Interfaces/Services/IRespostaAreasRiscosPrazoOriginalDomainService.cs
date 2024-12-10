using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IRespostaAreasRiscosPrazoOriginalDomainService : IDisposable
    {
        Task<RespostaAreasRiscosPrazoOriginal> AddAsync(RespostaAreasRiscosPrazoOriginal entity);
        Task<List<RespostaAreasRiscosPrazoOriginal>> AddListAsync(List<RespostaAreasRiscosPrazoOriginal> entity);
        Task<RespostaAreasRiscosPrazoOriginal> UpdateAsync(RespostaAreasRiscosPrazoOriginal entity);
        Task<RespostaAreasRiscosPrazoOriginal> DeleteAsync(long id);
        Task<RespostaAreasRiscosPrazoOriginal> GetByIdAsync(long id);
        Task<List<RespostaAreasRiscosPrazoOriginal>> GetAllAsync();
        Task<List<RespostaAreasRiscosPrazoOriginal>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<RespostaAreasRiscosPrazoOriginal>> GetAllAtivosAsync();
    }
}