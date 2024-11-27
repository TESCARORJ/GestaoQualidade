using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface INivelServicoAtendimentoMetaDomainService : IDisposable
    {
        Task<NivelServicoAtendimentoMeta> AddAsync(NivelServicoAtendimentoMeta entity);
        Task<NivelServicoAtendimentoMeta> UpdateAsync(NivelServicoAtendimentoMeta entity);
        Task<NivelServicoAtendimentoMeta> DeleteAsync(long id);
        Task<NivelServicoAtendimentoMeta> GetByIdAsync(long id);
        Task<List<NivelServicoAtendimentoMeta>> GetAllAsync();
        Task<List<NivelServicoAtendimentoMeta>> GetAllAtivosAsync();
    }
}