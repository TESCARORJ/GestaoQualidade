using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IEficaciaTreinamentoMetaDomainService : IDisposable
    {
        Task<EficaciaTreinamentoMeta> AddAsync(EficaciaTreinamentoMeta entity);
        Task<EficaciaTreinamentoMeta> UpdateAsync(EficaciaTreinamentoMeta entity);
        Task<EficaciaTreinamentoMeta> DeleteAsync(long id);
        Task<EficaciaTreinamentoMeta> GetByIdAsync(long id);
        Task<List<EficaciaTreinamentoMeta>> GetAllAsync();
        Task<List<EficaciaTreinamentoMeta>> GetAllAtivosAsync();
    }
}