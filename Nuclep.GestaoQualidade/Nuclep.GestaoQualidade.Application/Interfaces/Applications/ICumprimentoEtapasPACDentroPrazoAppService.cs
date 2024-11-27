using Nuclep.GestaoQualidade.Application.DTOs;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface ICumprimentoEtapasPACDentroPrazoAppService :  IDisposable
    {
        Task GararPerguntasAsync();

        //Task<CumprimentoEtapasPACDentroPrazoResponseDTO> AddAsync(CumprimentoEtapasPACDentroPrazoRequestDTO request);

        Task<CumprimentoEtapasPACDentroPrazoResponseDTO> UpdateAsync(long id, CumprimentoEtapasPACDentroPrazoRequestDTO request);  
        Task<CumprimentoEtapasPACDentroPrazoResponseDTO> DeleteAsync(long id);
        Task<CumprimentoEtapasPACDentroPrazoResponseDTO> GetByIdAsync(long id);
        Task<List<CumprimentoEtapasPACDentroPrazoResponseDTO>> GetAllAsync();
        Task<List<CumprimentoEtapasPACDentroPrazoResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<CumprimentoEtapasPACDentroPrazoResponseDTO>> GetAllAtivosAsync();
    }
}
