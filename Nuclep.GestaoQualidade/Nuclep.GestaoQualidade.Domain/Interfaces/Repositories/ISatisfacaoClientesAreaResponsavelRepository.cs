using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ISatisfacaoClientesAreaResponsavelRepository : IBaseRepository<SatisfacaoClientesAreaResponsavel, long>
    {
        Task<SatisfacaoClientesAreaResponsavel?> GetOneAsync(Expression<Func<SatisfacaoClientesAreaResponsavel, bool>> where);
        Task<SatisfacaoClientesAreaResponsavel?> GetByIdAsync(long id);
        Task<List<SatisfacaoClientesAreaResponsavel>> GetAllAsync();
        Task<List<SatisfacaoClientesAreaResponsavel>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<SatisfacaoClientesAreaResponsavel>> GetAllAtivosAsync();
    }
}
