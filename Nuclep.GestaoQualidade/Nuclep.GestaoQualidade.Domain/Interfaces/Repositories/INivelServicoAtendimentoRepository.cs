using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface INivelServicoAtendimentoRepository : IBaseRepository<NivelServicoAtendimento, long>
    {
        Task<NivelServicoAtendimento?> GetOneAsync(Expression<Func<NivelServicoAtendimento, bool>> where);
        Task<NivelServicoAtendimento?> GetByIdAsync(long id);
        Task<List<NivelServicoAtendimento>> GetAllAsync();
        Task<List<NivelServicoAtendimento>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<NivelServicoAtendimento>> GetAllAtivosAsync();
    }
}
