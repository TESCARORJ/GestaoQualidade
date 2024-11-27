using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ILocalidadeAppService :  IDisposable
    {
        Task<LocalidadeResponseDTO> AddAsync(LocalidadeRequestDTO request);
        Task<LocalidadeResponseDTO> UpdateAsync(long id, LocalidadeRequestDTO request);  
        Task<LocalidadeResponseDTO> DeleteAsync(long id);
        Task<LocalidadeResponseDTO> GetByIdAsync(long id);
        Task<LocalidadeResponseDTO> GetByNameAsync(string nome);
        Task<LocalidadeResponseDTO> GetByLoginAsync(string login);
        Task<List<LocalidadeResponseDTO>> GetByNameListAsync(string nome);
        Task<List<LocalidadeResponseDTO>> GetAllAsync();
        Task<List<LocalidadeResponseDTO>> GetAllAtivosAsync();
    }
}
