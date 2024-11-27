using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ITempoReparoEquipamentosProgramadosObrasRepository : IBaseRepository<TempoReparoEquipamentosProgramadosObras, long>
    {
        Task<TempoReparoEquipamentosProgramadosObras?> GetOneAsync(Expression<Func<TempoReparoEquipamentosProgramadosObras, bool>> where);
        Task<TempoReparoEquipamentosProgramadosObras?> GetByIdAsync(long id);
        Task<List<TempoReparoEquipamentosProgramadosObras>> GetAllAsync();
        Task<List<TempoReparoEquipamentosProgramadosObras>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoReparoEquipamentosProgramadosObras>> GetAllAtivosAsync();
    }
}
