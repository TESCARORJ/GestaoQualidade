using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface INivelServicoAtendimentoDomainService : IDisposable
    {
        Task<NivelServicoAtendimento> AddAsync(NivelServicoAtendimento entity);
        Task<NivelServicoAtendimento> UpdateAsync(NivelServicoAtendimento entity);
        Task<NivelServicoAtendimento> DeleteAsync(long id);
        Task<NivelServicoAtendimento> GetByIdAsync(long id);
        Task<List<NivelServicoAtendimento>> GetAllAsync();
        Task<List<NivelServicoAtendimento>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<NivelServicoAtendimento>> GetAllAtivosAsync();
    }
}