using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ITempoMedioSolucaoMetaDomainService : IDisposable
    {
        Task<TempoMedioSolucaoMeta> AddAsync(TempoMedioSolucaoMeta entity);
        Task<TempoMedioSolucaoMeta> UpdateAsync(TempoMedioSolucaoMeta entity);
        Task<TempoMedioSolucaoMeta> DeleteAsync(long id);
        Task<TempoMedioSolucaoMeta> GetByIdAsync(long id);
        Task<List<TempoMedioSolucaoMeta>> GetAllAsync();
        Task<List<TempoMedioSolucaoMeta>> GetAllAtivosAsync();
    }
}