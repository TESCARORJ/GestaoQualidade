using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface INaoConformidadeRepository : IBaseRepository<NaoConformidade, long>
    {
        Task<NaoConformidade?> GetOneAsync(Expression<Func<NaoConformidade, bool>> where);
        Task<NaoConformidade?> GetByIdAsync(long id);
        Task<List<NaoConformidade>> GetAllAsync();
        Task<List<NaoConformidade>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<NaoConformidade>> GetAllAtivosAsync();
    }
}
