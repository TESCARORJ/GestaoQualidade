using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Interfaces.Services
{
    public interface ILogCrudDomainService/* : IDisposable*/
    {
        Task<List<LogCrud>> GetAllAsync();
    }
}
