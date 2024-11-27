using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IDefeitoSoldagemMetaDomainService : IDisposable
    {
        Task<DefeitoSoldagemMeta> AddAsync(DefeitoSoldagemMeta entity);
        Task<DefeitoSoldagemMeta> UpdateAsync(DefeitoSoldagemMeta entity);
        Task<DefeitoSoldagemMeta> DeleteAsync(long id);
        Task<DefeitoSoldagemMeta> GetByIdAsync(long id);
        Task<List<DefeitoSoldagemMeta>> GetAllAsync();
        Task<List<DefeitoSoldagemMeta>> GetAllAtivosAsync();
    }
}
