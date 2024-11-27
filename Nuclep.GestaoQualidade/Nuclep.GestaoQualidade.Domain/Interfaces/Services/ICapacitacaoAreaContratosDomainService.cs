using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ICapacitacaoAreaContratosDomainService : IDisposable
    {
        Task<CapacitacaoAreaContratos> AddAsync(CapacitacaoAreaContratos entity);
        Task<CapacitacaoAreaContratos> UpdateAsync(CapacitacaoAreaContratos entity);
        Task<CapacitacaoAreaContratos> DeleteAsync(long id);
        Task<CapacitacaoAreaContratos> GetByIdAsync(long id);
        Task<List<CapacitacaoAreaContratos>> GetAllAsync();
        Task<List<CapacitacaoAreaContratos>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<CapacitacaoAreaContratos>> GetAllAtivosAsync();
    }
}
