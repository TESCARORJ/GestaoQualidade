using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ICapacitacaoAreaContratosRepository : IBaseRepository<CapacitacaoAreaContratos, long>
    {
        Task<CapacitacaoAreaContratos?> GetOneAsync(Expression<Func<CapacitacaoAreaContratos, bool>> where);
        Task<CapacitacaoAreaContratos?> GetByIdAsync(long id);
        Task<List<CapacitacaoAreaContratos>> GetAllAsync();
        Task<List<CapacitacaoAreaContratos>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<CapacitacaoAreaContratos>> GetAllAtivosAsync();
    }
}
