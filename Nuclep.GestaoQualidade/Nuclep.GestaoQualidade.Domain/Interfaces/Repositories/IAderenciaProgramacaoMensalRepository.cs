using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IAderenciaProgramacaoMensalRepository : IBaseRepository<AderenciaProgramacaoMensal, long>
    {
        Task<AderenciaProgramacaoMensal?> GetOneAsync(Expression<Func<AderenciaProgramacaoMensal, bool>> where);
        Task<AderenciaProgramacaoMensal?> GetByIdAsync(long id);
        Task<List<AderenciaProgramacaoMensal>> GetAllAsync();
        Task<List<AderenciaProgramacaoMensal>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<AderenciaProgramacaoMensal>> GetAllAtivosAsync();
    }
}
