using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ISatisfacaoClientesDomainService : IDisposable
    {
        Task<SatisfacaoClientes> AddAsync(SatisfacaoClientes entity);
        Task<List<SatisfacaoClientes>> AddListAsync(List<SatisfacaoClientes> entity);
        Task<SatisfacaoClientes> UpdateAsync(SatisfacaoClientes entity);
        Task<SatisfacaoClientes> DeleteAsync(long id);
        Task<SatisfacaoClientes> GetByIdAsync(long id);
        Task<List<SatisfacaoClientes>> GetAllAsync();
        Task<List<SatisfacaoClientes>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<SatisfacaoClientes>> GetAllAtivosAsync(); 
    }
}