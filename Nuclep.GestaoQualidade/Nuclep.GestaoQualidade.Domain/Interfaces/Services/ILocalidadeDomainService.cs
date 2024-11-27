using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ILocalidadeDomainService : IDisposable
    {
        Task<Localidade> AddAsync(Localidade entity);
        Task<Localidade> UpdateAsync(Localidade entity);
        Task<Localidade> DeleteAsync(long id);
        Task<Localidade> GetByIdAsync(long id);
        Task<Localidade> GetByNameAsync(string nome);
        Task<Localidade> GetByLoginAsync(string login);
        Task<List<Localidade>> GetByNameListAsync(string nome);
        Task<List<Localidade>> GetAllAsync();
        Task<List<Localidade>> GetAllAtivosAsync();
    }
}
