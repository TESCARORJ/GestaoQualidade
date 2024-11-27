using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IAderenciaProgramacaoMensalAppService :  IDisposable
    {
        Task GararPerguntasAsync();

        //Task<AderenciaProgramacaoMensalResponseDTO> AddAsync(AderenciaProgramacaoMensalRequestDTO request);

        Task<AderenciaProgramacaoMensalResponseDTO> UpdateAsync(long id, AderenciaProgramacaoMensalRequestDTO request);  
        Task<AderenciaProgramacaoMensalResponseDTO> DeleteAsync(long id);
        Task<AderenciaProgramacaoMensalResponseDTO> GetByIdAsync(long id);
        Task<List<AderenciaProgramacaoMensalResponseDTO>> GetAllAsync();
        Task<List<AderenciaProgramacaoMensalResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<AderenciaProgramacaoMensalResponseDTO>> GetAllAtivosAsync();
    }
}
