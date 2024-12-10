using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface INaoConformidadeDomainService : IDisposable
    {
        Task<NaoConformidade> AddAsync(NaoConformidade entity);
        Task<List<NaoConformidade>> AddListAsync(List<NaoConformidade> entity);
        Task<NaoConformidade> UpdateAsync(NaoConformidade entity);
        Task<NaoConformidade> DeleteAsync(long id);
        Task<NaoConformidade> GetByIdAsync(long id);
        Task<List<NaoConformidade>> GetAllAsync();
        Task<List<NaoConformidade>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<NaoConformidade>> GetAllAtivosAsync();
    }
}