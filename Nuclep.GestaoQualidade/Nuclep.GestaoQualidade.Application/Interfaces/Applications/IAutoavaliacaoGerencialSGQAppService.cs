using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IAutoavaliacaoGerencialSGQAppService :  IDisposable
    {
        Task GararPerguntasAsync();

        //Task<AutoavaliacaoGerencialSGQResponseDTO> AddAsync(AutoavaliacaoGerencialSGQRequestDTO request);

        Task<AutoavaliacaoGerencialSGQResponseDTO> UpdateAsync(long id, AutoavaliacaoGerencialSGQRequestDTO request);  
        Task<AutoavaliacaoGerencialSGQResponseDTO> DeleteAsync(long id);
        Task<AutoavaliacaoGerencialSGQResponseDTO> GetByIdAsync(long id);
        Task<List<AutoavaliacaoGerencialSGQResponseDTO>> GetAllAsync();
        Task<List<AutoavaliacaoGerencialSGQResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<AutoavaliacaoGerencialSGQResponseDTO>> GetAllAtivosAsync();
    }
}
