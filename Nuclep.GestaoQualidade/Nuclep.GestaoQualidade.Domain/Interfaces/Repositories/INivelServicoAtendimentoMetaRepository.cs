using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface INivelServicoAtendimentoMetaRepository : IBaseRepository<NivelServicoAtendimentoMeta, long>
    {
        Task<NivelServicoAtendimentoMeta?> GetOneAsync(Expression<Func<NivelServicoAtendimentoMeta, bool>> where);
        Task<NivelServicoAtendimentoMeta?> GetByIdAsync(long id);
        Task<List<NivelServicoAtendimentoMeta>> GetAllAsync();
        Task<List<NivelServicoAtendimentoMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<NivelServicoAtendimentoMeta>> GetAllAtivosAsync();
    }
}
