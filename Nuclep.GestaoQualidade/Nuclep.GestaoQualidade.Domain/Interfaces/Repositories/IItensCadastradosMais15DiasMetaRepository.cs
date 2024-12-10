using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IItensCadastradosMais15DiasMetaRepository : IBaseRepository<ItensCadastradosMais15DiasMeta, long>
    {
        Task<ItensCadastradosMais15DiasMeta?> GetOneAsync(Expression<Func<ItensCadastradosMais15DiasMeta, bool>> where);
        Task<ItensCadastradosMais15DiasMeta?> GetByIdAsync(long id);
        Task<List<ItensCadastradosMais15DiasMeta>> GetAllAsync();
        Task<List<ItensCadastradosMais15DiasMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<ItensCadastradosMais15DiasMeta>> GetAllAtivosAsync();
    }
}
