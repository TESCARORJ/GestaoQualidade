using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IAcaoDentroPrazoMetaDomainService : IDisposable
    {
        Task<AcaoDentroPrazoMeta> AddAsync(AcaoDentroPrazoMeta entity);
        Task<AcaoDentroPrazoMeta> UpdateAsync(AcaoDentroPrazoMeta entity);
        Task<AcaoDentroPrazoMeta> DeleteAsync(long id);
        Task<AcaoDentroPrazoMeta> GetByIdAsync(long id);
        Task<List<AcaoDentroPrazoMeta>> GetAllAsync();
        Task<List<AcaoDentroPrazoMeta>> GetAllAtivosAsync();
    }
    
}
