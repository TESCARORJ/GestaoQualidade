using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IDuracaoProcessoLicitacaoMetaDomainService : IDisposable
    {
        Task<DuracaoProcessoLicitacaoMeta> AddAsync(DuracaoProcessoLicitacaoMeta entity);
        Task<DuracaoProcessoLicitacaoMeta> UpdateAsync(DuracaoProcessoLicitacaoMeta entity);
        Task<DuracaoProcessoLicitacaoMeta> DeleteAsync(long id);
        Task<DuracaoProcessoLicitacaoMeta> GetByIdAsync(long id);
        Task<List<DuracaoProcessoLicitacaoMeta>> GetAllAsync();
        Task<List<DuracaoProcessoLicitacaoMeta>> GetAllAtivosAsync();
    }
}