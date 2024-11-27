using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface IAderenciaProgramacaoMensalDomainService : IDisposable
    {
        Task<AderenciaProgramacaoMensal> AddAsync(AderenciaProgramacaoMensal entity);
        Task<List<AderenciaProgramacaoMensal>> AddListAsync(List<AderenciaProgramacaoMensal> entity);
        Task<AderenciaProgramacaoMensal> UpdateAsync(AderenciaProgramacaoMensal entity);
        Task<AderenciaProgramacaoMensal> DeleteAsync(long id);
        Task<AderenciaProgramacaoMensal> GetByIdAsync(long id);
        Task<List<AderenciaProgramacaoMensal>> GetAllAsync();
        Task<List<AderenciaProgramacaoMensal>> GetAllUsarioLogadoAsync(long usuarioLogadoId);
        Task<List<AderenciaProgramacaoMensal>> GetAllAtivosAsync();
    }
}
