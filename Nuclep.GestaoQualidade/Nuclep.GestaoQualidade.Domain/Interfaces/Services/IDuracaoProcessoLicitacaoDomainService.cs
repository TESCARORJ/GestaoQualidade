using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IDuracaoProcessoLicitacaoDomainService : IDisposable
    {
        Task<DuracaoProcessoLicitacao> AddAsync(DuracaoProcessoLicitacao entity);
        Task<List<DuracaoProcessoLicitacao>> AddListAsync(List<DuracaoProcessoLicitacao> entity);

        Task<DuracaoProcessoLicitacao> UpdateAsync(DuracaoProcessoLicitacao entity);
        Task<DuracaoProcessoLicitacao> DeleteAsync(long id);
        Task<DuracaoProcessoLicitacao> GetByIdAsync(long id);
        Task<List<DuracaoProcessoLicitacao>> GetAllAsync();
        Task<List<DuracaoProcessoLicitacao>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<DuracaoProcessoLicitacao>> GetAllAtivosAsync();
    }
}