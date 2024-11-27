using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IUsuarioAppService :  IDisposable
    {
        Task<UsuarioResponseDTO> AddAsync(string nomeAD);
        Task<UsuarioResponseDTO> UpdateAsync(long id, UsuarioRequestDTO request);  
        Task<UsuarioResponseDTO> DeleteAsync(long id);
        Task<UsuarioResponseDTO> GetByIdAsync(long id);
        Task<UsuarioResponseDTO> GetByNameAsync(string nome);
        Task<UsuarioResponseDTO> GetByLoginAsync(string login);
        Task<List<UsuarioResponseDTO>> GetByNameListAsync(string nome);
        Task<List<UsuarioResponseDTO>> GetAllAsync();
        Task<List<UsuarioResponseDTO>> GetAllAtivosAsync();
        Task<bool> ExisteUsuario(string nomeAD);
    }
}
