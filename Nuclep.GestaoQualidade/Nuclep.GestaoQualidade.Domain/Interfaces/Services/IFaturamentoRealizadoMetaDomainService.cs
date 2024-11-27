using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IFaturamentoRealizadoMetaDomainService : IDisposable
    {
        Task<FaturamentoRealizadoMeta> AddAsync(FaturamentoRealizadoMeta entity);
        Task<FaturamentoRealizadoMeta> UpdateAsync(FaturamentoRealizadoMeta entity);
        Task<FaturamentoRealizadoMeta> DeleteAsync(long id);
        Task<FaturamentoRealizadoMeta> GetByIdAsync(long id);
        Task<List<FaturamentoRealizadoMeta>> GetAllAsync();
        Task<List<FaturamentoRealizadoMeta>> GetAllAtivosAsync();
    }
}