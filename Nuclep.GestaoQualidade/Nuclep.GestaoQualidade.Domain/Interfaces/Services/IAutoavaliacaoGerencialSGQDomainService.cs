using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IAutoavaliacaoGerencialSGQDomainService : IDisposable
    {
        Task<AutoavaliacaoGerencialSGQ> AddAsync(AutoavaliacaoGerencialSGQ entity);
        Task<List<AutoavaliacaoGerencialSGQ>> AddListAsync(List<AutoavaliacaoGerencialSGQ> entity);

        Task<AutoavaliacaoGerencialSGQ> UpdateAsync(AutoavaliacaoGerencialSGQ entity);
        Task<AutoavaliacaoGerencialSGQ> DeleteAsync(long id);
        Task<AutoavaliacaoGerencialSGQ> GetByIdAsync(long id);
        Task<List<AutoavaliacaoGerencialSGQ>> GetAllAsync();
        Task<List<AutoavaliacaoGerencialSGQ>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<AutoavaliacaoGerencialSGQ>> GetAllAtivosAsync();
    }
}
