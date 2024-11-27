using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IDefeitoSoldagemDomainService : IDisposable
    {
        Task<DefeitoSoldagem> AddAsync(DefeitoSoldagem entity);
        Task<List<DefeitoSoldagem>> AddListAsync(List<DefeitoSoldagem> entity);
        Task<DefeitoSoldagem> UpdateAsync(DefeitoSoldagem entity);
        Task<DefeitoSoldagem> DeleteAsync(long id);
        Task<DefeitoSoldagem> GetByIdAsync(long id);
        Task<List<DefeitoSoldagem>> GetAllAsync();
        Task<List<DefeitoSoldagem>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<DefeitoSoldagem>> GetAllAtivosAsync();
    }
}
