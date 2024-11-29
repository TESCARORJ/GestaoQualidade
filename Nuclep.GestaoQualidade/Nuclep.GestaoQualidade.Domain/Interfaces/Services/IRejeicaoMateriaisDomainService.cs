using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IRejeicaoMateriaisDomainService : IDisposable
    {
        Task<RejeicaoMateriais> AddAsync(RejeicaoMateriais entity);
        Task<List<RejeicaoMateriais>> AddListAsync(List<RejeicaoMateriais> entity);
        Task<RejeicaoMateriais> UpdateAsync(RejeicaoMateriais entity);
        Task<RejeicaoMateriais> DeleteAsync(long id);
        Task<RejeicaoMateriais> GetByIdAsync(long id);
        Task<List<RejeicaoMateriais>> GetAllAsync();
        Task<List<RejeicaoMateriais>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<RejeicaoMateriais>> GetAllAtivosAsync();
    }
}