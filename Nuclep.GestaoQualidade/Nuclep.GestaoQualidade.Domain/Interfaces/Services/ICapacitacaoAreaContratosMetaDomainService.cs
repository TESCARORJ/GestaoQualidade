using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ICapacitacaoAreaContratosMetaDomainService : IDisposable
    {
        Task<AcaoCorrecaoAvaliadaEficazMeta> AddAsync(AcaoCorrecaoAvaliadaEficazMeta entity);
        Task<AcaoCorrecaoAvaliadaEficazMeta> UpdateAsync(AcaoCorrecaoAvaliadaEficazMeta entity);
        Task<AcaoCorrecaoAvaliadaEficazMeta> DeleteAsync(long id);
        Task<AcaoCorrecaoAvaliadaEficazMeta> GetByIdAsync(long id);
        Task<List<AcaoCorrecaoAvaliadaEficazMeta>> GetAllAsync();
        Task<List<AcaoCorrecaoAvaliadaEficazMeta>> GetAllAtivosAsync();
    }
}
