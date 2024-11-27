using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IGestaoProcessosPessoasPrevistoPATRepository : IBaseRepository<GestaoProcessosPessoasPrevistoPAT, long>
    {
        Task<GestaoProcessosPessoasPrevistoPAT?> GetOneAsync(Expression<Func<GestaoProcessosPessoasPrevistoPAT, bool>> where);
        Task<GestaoProcessosPessoasPrevistoPAT?> GetByIdAsync(long id);
        Task<List<GestaoProcessosPessoasPrevistoPAT>> GetAllAsync();
        Task<List<GestaoProcessosPessoasPrevistoPAT>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<GestaoProcessosPessoasPrevistoPAT>> GetAllAtivosAsync();
    }
}
