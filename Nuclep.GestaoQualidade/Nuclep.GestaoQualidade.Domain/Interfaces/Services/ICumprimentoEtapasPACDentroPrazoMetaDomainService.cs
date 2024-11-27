using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ICumprimentoEtapasPACDentroPrazoMetaDomainService : IDisposable
    {
        Task<CumprimentoEtapasPACDentroPrazoMeta> AddAsync(CumprimentoEtapasPACDentroPrazoMeta entity);
        Task<CumprimentoEtapasPACDentroPrazoMeta> UpdateAsync(CumprimentoEtapasPACDentroPrazoMeta entity);
        Task<CumprimentoEtapasPACDentroPrazoMeta> DeleteAsync(long id);
        Task<CumprimentoEtapasPACDentroPrazoMeta> GetByIdAsync(long id);
        Task<List<CumprimentoEtapasPACDentroPrazoMeta>> GetAllAsync();
        Task<List<CumprimentoEtapasPACDentroPrazoMeta>> GetAllAtivosAsync();
    }
}
