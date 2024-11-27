using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService : IDisposable
    {
        Task<Usuario> AddAsync(Usuario entity);
        Task<Usuario> UpdateAsync(Usuario entity);
        Task<Usuario> DeleteAsync(long id);
        Task<Usuario> GetByIdAsync(long id);
        Task<Usuario> GetByNameAsync(string nome);
        Task<Usuario> GetByLoginAsync(string login);
        Task<List<Usuario>> GetByNameListAsync(string nome);
        Task<List<Usuario>> GetAllAsync();
        Task<List<Usuario>> GetAllAtivosAsync();
        Task<bool> ExisteUsuario(string nomeAD);
    }
}
