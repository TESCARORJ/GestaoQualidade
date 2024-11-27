using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IProdutividadeMaoObraMetaDomainService : IDisposable
    {
        Task<ProdutividadeMaoObraMeta> AddAsync(ProdutividadeMaoObraMeta entity);
        Task<ProdutividadeMaoObraMeta> UpdateAsync(ProdutividadeMaoObraMeta entity);
        Task<ProdutividadeMaoObraMeta> DeleteAsync(long id);
        Task<ProdutividadeMaoObraMeta> GetByIdAsync(long id);
        Task<List<ProdutividadeMaoObraMeta>> GetAllAsync();
        Task<List<ProdutividadeMaoObraMeta>> GetAllAtivosAsync();
    }
}