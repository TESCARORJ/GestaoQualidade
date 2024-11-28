using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IEficaciaTreinamentoDomainService : IDisposable
    {
        Task<EficaciaTreinamento> AddAsync(EficaciaTreinamento entity);
        Task<List<EficaciaTreinamento>> AddListAsync(List<EficaciaTreinamento> entity);

        Task<EficaciaTreinamento> UpdateAsync(EficaciaTreinamento entity);
        Task<EficaciaTreinamento> DeleteAsync(long id);
        Task<EficaciaTreinamento> GetByIdAsync(long id);
        Task<List<EficaciaTreinamento>> GetAllAsync();
        Task<List<EficaciaTreinamento>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<EficaciaTreinamento>> GetAllAtivosAsync();
    }
}