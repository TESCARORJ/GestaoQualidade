using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IAutoavaliacaoGerencialSGQMetaDomainService : IDisposable
    {
        Task<AutoavaliacaoGerencialSGQMeta> AddAsync(AutoavaliacaoGerencialSGQMeta entity);
        Task<AutoavaliacaoGerencialSGQMeta> UpdateAsync(AutoavaliacaoGerencialSGQMeta entity);
        Task<AutoavaliacaoGerencialSGQMeta> DeleteAsync(long id);
        Task<AutoavaliacaoGerencialSGQMeta> GetByIdAsync(long id);
        Task<List<AutoavaliacaoGerencialSGQMeta>> GetAllAsync();
        Task<List<AutoavaliacaoGerencialSGQMeta>> GetAllAtivosAsync();
    }
}
