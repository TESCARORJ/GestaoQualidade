using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IAderenciaProgramacaoMensalMetaDomainService : IDisposable
    {
        Task<AderenciaProgramacaoMensalMeta> AddAsync(AderenciaProgramacaoMensalMeta entity);
        Task<AderenciaProgramacaoMensalMeta> UpdateAsync(AderenciaProgramacaoMensalMeta entity);
        Task<AderenciaProgramacaoMensalMeta> DeleteAsync(long id);
        Task<AderenciaProgramacaoMensalMeta> GetByIdAsync(long id);
        Task<List<AderenciaProgramacaoMensalMeta>> GetAllAsync();
        Task<List<AderenciaProgramacaoMensalMeta>> GetAllAtivosAsync();
    }
}
