using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IRejeicaoMateriaisAppService :  IDisposable
    {
        Task GararPerguntasAsync();

        Task<RejeicaoMateriaisResponseDTO> UpdateAsync(long id, RejeicaoMateriaisRequestDTO request);  
        Task<RejeicaoMateriaisResponseDTO> DeleteAsync(long id);
        Task<RejeicaoMateriaisResponseDTO> GetByIdAsync(long id);
        Task<List<RejeicaoMateriaisResponseDTO>> GetAllAsync();
        Task<List<RejeicaoMateriaisResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<RejeicaoMateriaisResponseDTO>> GetAllAtivosAsync();
    }
}
