using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IItensCadastradosMais15DiasDomainService : IDisposable
    {
        Task<ItensCadastradosMais15Dias> AddAsync(ItensCadastradosMais15Dias entity);
        Task<List<ItensCadastradosMais15Dias>> AddListAsync(List<ItensCadastradosMais15Dias> entity);
        Task<ItensCadastradosMais15Dias> UpdateAsync(ItensCadastradosMais15Dias entity);
        Task<ItensCadastradosMais15Dias> DeleteAsync(long id);
        Task<ItensCadastradosMais15Dias> GetByIdAsync(long id);
        Task<List<ItensCadastradosMais15Dias>> GetAllAsync();
        Task<List<ItensCadastradosMais15Dias>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<ItensCadastradosMais15Dias>> GetAllAtivosAsync();
    }
}