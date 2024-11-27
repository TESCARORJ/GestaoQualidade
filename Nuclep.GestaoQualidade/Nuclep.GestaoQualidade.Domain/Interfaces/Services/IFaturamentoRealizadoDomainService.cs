using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IFaturamentoRealizadoDomainService : IDisposable
    {
        Task<FaturamentoRealizado> AddAsync(FaturamentoRealizado entity);
        Task<List<FaturamentoRealizado>> AddListAsync(List<FaturamentoRealizado> entity);
        Task<FaturamentoRealizado> UpdateAsync(FaturamentoRealizado entity);
        Task<FaturamentoRealizado> DeleteAsync(long id);
        Task<FaturamentoRealizado> GetByIdAsync(long id);
        Task<List<FaturamentoRealizado>> GetAllAsync();
        Task<List<FaturamentoRealizado>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<FaturamentoRealizado>> GetAllAtivosAsync();
    }
}