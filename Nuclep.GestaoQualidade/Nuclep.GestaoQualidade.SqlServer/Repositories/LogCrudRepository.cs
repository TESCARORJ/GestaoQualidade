using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using Nuclep.GestaoQualidade.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.SqlServer.Repositories
{
    public class LogCrudRepository : BaseRepository<LogCrud, long>, ILogCrudRepository
    {
        private readonly DataContext _dataContext;
        public LogCrudRepository(DataContext context, DataContext dataContext) : base(context)
        {
            _dataContext = dataContext;
        }

        public async Task<List<LogCrud>> GetAll()
        {
            var result =  await _dataContext.Set<LogCrud>().Include(x => x.LogTabela).ToListAsync();
            return result;
        }
    }
}
