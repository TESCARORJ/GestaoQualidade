using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IGestaoProcessosPessoasPrevistoPATDomainService : IDisposable
    {
        Task<GestaoProcessosPessoasPrevistoPAT> AddAsync(GestaoProcessosPessoasPrevistoPAT entity);
        Task<GestaoProcessosPessoasPrevistoPAT> UpdateAsync(GestaoProcessosPessoasPrevistoPAT entity);
        Task<GestaoProcessosPessoasPrevistoPAT> DeleteAsync(long id);
        Task<GestaoProcessosPessoasPrevistoPAT> GetByIdAsync(long id);
        Task<List<GestaoProcessosPessoasPrevistoPAT>> GetAllAsync();
        Task<List<GestaoProcessosPessoasPrevistoPAT>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<GestaoProcessosPessoasPrevistoPAT>> GetAllAtivosAsync();
    }
}