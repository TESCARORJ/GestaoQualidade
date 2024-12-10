using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using Nuclep.GestaoQualidade.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.SqlServer.Repositories
{
    public class LogTabelaRepository : BaseRepository<LogTabela, long>, ILogTabelaRepository
    {
        private readonly DataContext _context;
        public LogTabelaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Task<LogTabela> GetOneAsync(Expression<Func<LogTabela, bool>> where)
        {
            return _context.Set<LogTabela>()
                                 .Where(where)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync();
        }

        public async Task<LogTabela> GetByIdAsync(long id)
        {
            return await _context.Set<LogTabela>()
                                 .Where(x => x.Id == id)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<LogTabela>> GetAllAsync()
        {
            return await _context.Set<LogTabela>()
                                 .Where(x => x.Id > 0)
                                 .AsNoTracking()
                                 .ToListAsync();
        }
      
    }
}
