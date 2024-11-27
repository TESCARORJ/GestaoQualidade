using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IOcupacaoMaoObraDomainService : IDisposable
    {
        Task<OcupacaoMaoObra> AddAsync(OcupacaoMaoObra entity);
        Task<OcupacaoMaoObra> UpdateAsync(OcupacaoMaoObra entity);
        Task<OcupacaoMaoObra> DeleteAsync(long id);
        Task<OcupacaoMaoObra> GetByIdAsync(long id);
        Task<List<OcupacaoMaoObra>> GetAllAsync();
        Task<List<OcupacaoMaoObra>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<OcupacaoMaoObra>> GetAllAtivosAsync();
    }
}