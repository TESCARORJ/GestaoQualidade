using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IProdutividadeMaoObraDomainService : IDisposable
    {
        Task<ProdutividadeMaoObra> AddAsync(ProdutividadeMaoObra entity);
        Task<ProdutividadeMaoObra> UpdateAsync(ProdutividadeMaoObra entity);
        Task<ProdutividadeMaoObra> DeleteAsync(long id);
        Task<ProdutividadeMaoObra> GetByIdAsync(long id);
        Task<List<ProdutividadeMaoObra>> GetAllAsync();
        Task<List<ProdutividadeMaoObra>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<ProdutividadeMaoObra>> GetAllAtivosAsync();
    }
}