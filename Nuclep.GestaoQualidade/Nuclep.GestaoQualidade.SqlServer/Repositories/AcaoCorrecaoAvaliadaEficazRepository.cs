using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
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
    public class AcaoCorrecaoAvaliadaEficazRepository : BaseRepository<AcaoCorrecaoAvaliadaEficaz, long>, IAcaoCorrecaoAvaliadaEficazRepository
    {
        private readonly DataContext _context;
        public AcaoCorrecaoAvaliadaEficazRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AcaoCorrecaoAvaliadaEficaz?> GetOneAsync(Expression<Func<AcaoCorrecaoAvaliadaEficaz, bool>> where)
        {
            return await _context.Set<AcaoCorrecaoAvaliadaEficaz>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<AcaoCorrecaoAvaliadaEficaz?> GetByIdAsync(long id)
        {
            return await _context.Set<AcaoCorrecaoAvaliadaEficaz>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<AcaoCorrecaoAvaliadaEficaz>> GetAllAsync()
        {
            return await _context.Set<AcaoCorrecaoAvaliadaEficaz>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<AcaoCorrecaoAvaliadaEficaz>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<AcaoCorrecaoAvaliadaEficaz>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<AcaoCorrecaoAvaliadaEficaz>> GetAllAtivosAsync()
        {
            return await _context.Set<AcaoCorrecaoAvaliadaEficaz>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }
}
