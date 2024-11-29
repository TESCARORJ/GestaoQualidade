using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IRejeicaoMateriaisMetaDomainService : IDisposable
    {
        Task<RejeicaoMateriaisMeta> AddAsync(RejeicaoMateriaisMeta entity);
        Task<RejeicaoMateriaisMeta> UpdateAsync(RejeicaoMateriaisMeta entity);
        Task<RejeicaoMateriaisMeta> DeleteAsync(long id);
        Task<RejeicaoMateriaisMeta> GetByIdAsync(long id);
        Task<List<RejeicaoMateriaisMeta>> GetAllAsync();
        Task<List<RejeicaoMateriaisMeta>> GetAllAtivosAsync();
    }
}