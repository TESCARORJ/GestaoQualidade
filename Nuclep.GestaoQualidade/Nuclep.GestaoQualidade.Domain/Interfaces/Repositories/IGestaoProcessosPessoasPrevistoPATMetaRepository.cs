using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IGestaoProcessosPessoasPrevistoPATMetaRepository : IBaseRepository<GestaoProcessosPessoasPrevistoPATMeta, long>
    {
        Task<GestaoProcessosPessoasPrevistoPATMeta?> GetOneAsync(Expression<Func<GestaoProcessosPessoasPrevistoPATMeta, bool>> where);
        Task<GestaoProcessosPessoasPrevistoPATMeta?> GetByIdAsync(long id);
        Task<List<GestaoProcessosPessoasPrevistoPATMeta>> GetAllAsync();
        Task<List<GestaoProcessosPessoasPrevistoPATMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<GestaoProcessosPessoasPrevistoPATMeta>> GetAllAtivosAsync();
    }
}
