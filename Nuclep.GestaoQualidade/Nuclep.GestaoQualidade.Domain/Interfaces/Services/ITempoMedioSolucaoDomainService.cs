using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ITempoMedioSolucaoDomainService : IDisposable
    {
        Task<TempoMedioSolucao> AddAsync(TempoMedioSolucao entity);
        Task<TempoMedioSolucao> UpdateAsync(TempoMedioSolucao entity);
        Task<TempoMedioSolucao> DeleteAsync(long id);
        Task<TempoMedioSolucao> GetByIdAsync(long id);
        Task<List<TempoMedioSolucao>> GetAllAsync();
        Task<List<TempoMedioSolucao>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoMedioSolucao>> GetAllAtivosAsync();
    }
}