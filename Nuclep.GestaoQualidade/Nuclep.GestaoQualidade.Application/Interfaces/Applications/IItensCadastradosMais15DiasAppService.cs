using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IItensCadastradosMais15DiasAppService : IDisposable
    {

        Task GararPerguntasAsync();
        Task<ItensCadastradosMais15DiasResponseDTO> UpdateAsync(long id, ItensCadastradosMais15DiasRequestDTO request);
        Task<ItensCadastradosMais15DiasResponseDTO> DeleteAsync(long id);
        Task<ItensCadastradosMais15DiasResponseDTO> GetByIdAsync(long id);
        Task<List<ItensCadastradosMais15DiasResponseDTO>> GetAllAsync();
        Task<List<ItensCadastradosMais15DiasResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<ItensCadastradosMais15DiasResponseDTO>> GetAllAtivosAsync();
    }
}
