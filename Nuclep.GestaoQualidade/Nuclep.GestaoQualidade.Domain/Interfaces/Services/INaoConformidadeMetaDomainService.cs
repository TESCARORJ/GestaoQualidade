using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface INaoConformidadeMetaDomainService : IDisposable
    {
        Task<NaoConformidadeMeta> AddAsync(NaoConformidadeMeta entity);
        Task<NaoConformidadeMeta> UpdateAsync(NaoConformidadeMeta entity);
        Task<NaoConformidadeMeta> DeleteAsync(long id);
        Task<NaoConformidadeMeta> GetByIdAsync(long id);
        Task<List<NaoConformidadeMeta>> GetAllAsync();
        Task<List<NaoConformidadeMeta>> GetAllAtivosAsync();
    }
}