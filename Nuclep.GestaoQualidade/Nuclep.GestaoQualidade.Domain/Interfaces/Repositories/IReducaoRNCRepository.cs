using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IItensCadastradosMais15DiasRepository : IBaseRepository<ItensCadastradosMais15Dias, long>
    {
        Task<ItensCadastradosMais15Dias?> GetOneAsync(Expression<Func<ItensCadastradosMais15Dias, bool>> where);
        Task<ItensCadastradosMais15Dias?> GetByIdAsync(long id);
        Task<List<ItensCadastradosMais15Dias>> GetAllAsync();
        Task<List<ItensCadastradosMais15Dias>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<ItensCadastradosMais15Dias>> GetAllAtivosAsync();
    }
}
