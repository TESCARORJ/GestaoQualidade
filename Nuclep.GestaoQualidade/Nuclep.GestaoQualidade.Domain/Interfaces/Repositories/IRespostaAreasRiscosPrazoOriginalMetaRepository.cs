using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IRespostaAreasRiscosPrazoOriginalMetaRepository : IBaseRepository<RespostaAreasRiscosPrazoOriginalMeta, long>
    {
        Task<RespostaAreasRiscosPrazoOriginalMeta?> GetOneAsync(Expression<Func<RespostaAreasRiscosPrazoOriginalMeta, bool>> where);
        Task<RespostaAreasRiscosPrazoOriginalMeta?> GetByIdAsync(long id);
        Task<List<RespostaAreasRiscosPrazoOriginalMeta>> GetAllAsync();
        Task<List<RespostaAreasRiscosPrazoOriginalMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<RespostaAreasRiscosPrazoOriginalMeta>> GetAllAtivosAsync();
    }
}
