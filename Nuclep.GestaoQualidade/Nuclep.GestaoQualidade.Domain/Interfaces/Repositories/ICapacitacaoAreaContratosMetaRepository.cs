using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ICapacitacaoAreaContratosMetaRepository : IBaseRepository<CapacitacaoAreaContratosMeta, long>
    {
        Task<CapacitacaoAreaContratosMeta?> GetOneAsync(Expression<Func<CapacitacaoAreaContratosMeta, bool>> where);
        Task<CapacitacaoAreaContratosMeta?> GetByIdAsync(long id);
        Task<List<CapacitacaoAreaContratosMeta>> GetAllAsync();
        Task<List<CapacitacaoAreaContratosMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<CapacitacaoAreaContratosMeta>> GetAllAtivosAsync();
    }
}
