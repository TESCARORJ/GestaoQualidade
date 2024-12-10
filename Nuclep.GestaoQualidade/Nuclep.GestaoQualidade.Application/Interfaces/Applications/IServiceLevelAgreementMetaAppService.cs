using Nuclep.GestaoQualidade.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Application.Interfaces.Applications
{
    public interface IServiceLevelAgreementMetaAppService : IDisposable
    {
        Task<ServiceLevelAgreementMetaResponseDTO> AddAsync(ServiceLevelAgreementMetaRequestDTO request);
        Task<ServiceLevelAgreementMetaResponseDTO> UpdateAsync(long id, ServiceLevelAgreementMetaRequestDTO request);
        Task<ServiceLevelAgreementMetaResponseDTO> DeleteAsync(long id);
        Task<ServiceLevelAgreementMetaResponseDTO> GetByIdAsync(long id);
        Task<List<ServiceLevelAgreementMetaResponseDTO>> GetAllAsync();
        Task<List<ServiceLevelAgreementMetaResponseDTO>> GetAllAtivosAsync();
    }

}
