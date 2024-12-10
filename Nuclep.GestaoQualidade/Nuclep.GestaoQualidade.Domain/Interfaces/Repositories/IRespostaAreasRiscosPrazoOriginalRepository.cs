using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Repositories
{
    public interface IRespostaAreasRiscosPrazoOriginalRepository : IBaseRepository<RespostaAreasRiscosPrazoOriginal, long>
    {
        Task<RespostaAreasRiscosPrazoOriginal?> GetOneAsync(Expression<Func<RespostaAreasRiscosPrazoOriginal, bool>> where);
        Task<RespostaAreasRiscosPrazoOriginal?> GetByIdAsync(long id);
        Task<List<RespostaAreasRiscosPrazoOriginal>> GetAllAsync();
        Task<List<RespostaAreasRiscosPrazoOriginal>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<RespostaAreasRiscosPrazoOriginal>> GetAllAtivosAsync();
    }
}
