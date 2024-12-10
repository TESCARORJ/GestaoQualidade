using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface INaoConformidadeMetaRepository : IBaseRepository<NaoConformidadeMeta, long>
    {
        Task<NaoConformidadeMeta?> GetOneAsync(Expression<Func<NaoConformidadeMeta, bool>> where);
        Task<NaoConformidadeMeta?> GetByIdAsync(long id);
        Task<List<NaoConformidadeMeta>> GetAllAsync();
        Task<List<NaoConformidadeMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<NaoConformidadeMeta>> GetAllAtivosAsync();
    }
}
