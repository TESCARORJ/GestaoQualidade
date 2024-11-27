using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IOcupacaoMaoObraMetaDomainService : IDisposable
    {
        Task<OcupacaoMaoObraMeta> AddAsync(OcupacaoMaoObraMeta entity);
        Task<OcupacaoMaoObraMeta> UpdateAsync(OcupacaoMaoObraMeta entity);
        Task<OcupacaoMaoObraMeta> DeleteAsync(long id);
        Task<OcupacaoMaoObraMeta> GetByIdAsync(long id);
        Task<List<OcupacaoMaoObraMeta>> GetAllAsync();
        Task<List<OcupacaoMaoObraMeta>> GetAllAtivosAsync();
    }
}