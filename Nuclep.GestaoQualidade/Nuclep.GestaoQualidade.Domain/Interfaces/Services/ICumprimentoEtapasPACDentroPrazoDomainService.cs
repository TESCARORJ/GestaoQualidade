using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ICumprimentoEtapasPACDentroPrazoDomainService : IDisposable
    {
        Task<CumprimentoEtapasPACDentroPrazo> AddAsync(CumprimentoEtapasPACDentroPrazo entity);
        Task<List<CumprimentoEtapasPACDentroPrazo>> AddListAsync(List<CumprimentoEtapasPACDentroPrazo> entity);
        Task<CumprimentoEtapasPACDentroPrazo> UpdateAsync(CumprimentoEtapasPACDentroPrazo entity);
        Task<CumprimentoEtapasPACDentroPrazo> DeleteAsync(long id);
        Task<CumprimentoEtapasPACDentroPrazo> GetByIdAsync(long id);
        Task<List<CumprimentoEtapasPACDentroPrazo>> GetAllAsync();
        Task<List<CumprimentoEtapasPACDentroPrazo>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<CumprimentoEtapasPACDentroPrazo>> GetAllAtivosAsync();
    }
}
