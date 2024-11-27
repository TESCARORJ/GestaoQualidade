using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ISatisfacaoClientesAreaResponsavelMetaRepository : IBaseRepository<SatisfacaoClientesAreaResponsavelMeta, long>
    {
        Task<SatisfacaoClientesAreaResponsavelMeta?> GetOneAsync(Expression<Func<SatisfacaoClientesAreaResponsavelMeta, bool>> where);
        Task<SatisfacaoClientesAreaResponsavelMeta?> GetByIdAsync(long id);
        Task<List<SatisfacaoClientesAreaResponsavelMeta>> GetAllAsync();
        Task<List<SatisfacaoClientesAreaResponsavelMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<SatisfacaoClientesAreaResponsavelMeta>> GetAllAtivosAsync();
    }
}
