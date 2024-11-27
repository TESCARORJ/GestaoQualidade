using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IGestaoProcessosPessoasPrevistoPATMetaDomainService : IDisposable
    {
        Task<GestaoProcessosPessoasPrevistoPATMeta> AddAsync(GestaoProcessosPessoasPrevistoPATMeta entity);
        Task<GestaoProcessosPessoasPrevistoPATMeta> UpdateAsync(GestaoProcessosPessoasPrevistoPATMeta entity);
        Task<GestaoProcessosPessoasPrevistoPATMeta> DeleteAsync(long id);
        Task<GestaoProcessosPessoasPrevistoPATMeta> GetByIdAsync(long id);
        Task<List<GestaoProcessosPessoasPrevistoPATMeta>> GetAllAsync();
        Task<List<GestaoProcessosPessoasPrevistoPATMeta>> GetAllAtivosAsync();
    }
}