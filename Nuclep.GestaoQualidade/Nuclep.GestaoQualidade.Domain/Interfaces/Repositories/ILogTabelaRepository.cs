using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ILogTabelaRepository : IBaseRepository<LogTabela, long>
    {
        Task<LogTabela> GetOneAsync(Expression<Func<LogTabela, bool>> where);
        Task<LogTabela> GetByIdAsync(long id);
        Task<List<LogTabela>> GetAllAsync();
      
    }
}
