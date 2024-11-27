using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IItensCadastradosMais15DiasMetaDomainService : IDisposable
    {
        Task<ItensCadastradosMais15DiasMeta> AddAsync(ItensCadastradosMais15DiasMeta entity);
        Task<ItensCadastradosMais15DiasMeta> UpdateAsync(ItensCadastradosMais15DiasMeta entity);
        Task<ItensCadastradosMais15DiasMeta> DeleteAsync(long id);
        Task<ItensCadastradosMais15DiasMeta> GetByIdAsync(long id);
        Task<List<ItensCadastradosMais15DiasMeta>> GetAllAsync();
        Task<List<ItensCadastradosMais15DiasMeta>> GetAllAtivosAsync();
    }
}