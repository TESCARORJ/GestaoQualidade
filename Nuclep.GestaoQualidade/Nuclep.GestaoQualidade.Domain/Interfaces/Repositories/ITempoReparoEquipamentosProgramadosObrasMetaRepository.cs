using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface ITempoReparoEquipamentosProgramadosObrasMetaRepository : IBaseRepository<TempoReparoEquipamentosProgramadosObrasMeta, long>
    {
        Task<TempoReparoEquipamentosProgramadosObrasMeta?> GetOneAsync(Expression<Func<TempoReparoEquipamentosProgramadosObrasMeta, bool>> where);
        Task<TempoReparoEquipamentosProgramadosObrasMeta?> GetByIdAsync(long id);
        Task<List<TempoReparoEquipamentosProgramadosObrasMeta>> GetAllAsync();
        Task<List<TempoReparoEquipamentosProgramadosObrasMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<TempoReparoEquipamentosProgramadosObrasMeta>> GetAllAtivosAsync();
    }
}
