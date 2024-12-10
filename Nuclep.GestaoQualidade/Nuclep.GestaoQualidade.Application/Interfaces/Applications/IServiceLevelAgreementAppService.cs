using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IServiceLevelAgreementAppService : IDisposable
    {

        Task GararPerguntasAsync();
        Task<ServiceLevelAgreementResponseDTO> UpdateAsync(long id, ServiceLevelAgreementRequestDTO request);
        Task<ServiceLevelAgreementResponseDTO> DeleteAsync(long id);
        Task<ServiceLevelAgreementResponseDTO> GetByIdAsync(long id);
        Task<List<ServiceLevelAgreementResponseDTO>> GetAllAsync();
        Task<List<ServiceLevelAgreementResponseDTO>> GetAllUsarioLogadoAsync();
        Task<List<ServiceLevelAgreementResponseDTO>> GetAllAtivosAsync();
    }
}
