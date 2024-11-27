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
    public class AutoavaliacaoGerencialSGQRepository : BaseRepository<AutoavaliacaoGerencialSGQ, long>, IAutoavaliacaoGerencialSGQRepository
    {
        private readonly DataContext _context;
        public AutoavaliacaoGerencialSGQRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AutoavaliacaoGerencialSGQ?> GetOneAsync(Expression<Func<AutoavaliacaoGerencialSGQ, bool>> where)
        {
            return await _context.Set<AutoavaliacaoGerencialSGQ>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<AutoavaliacaoGerencialSGQ?> GetByIdAsync(long id)
        {
            return await _context.Set<AutoavaliacaoGerencialSGQ>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<AutoavaliacaoGerencialSGQ>> GetAllAsync()
        {
            return await _context.Set<AutoavaliacaoGerencialSGQ>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<AutoavaliacaoGerencialSGQ>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<AutoavaliacaoGerencialSGQ>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<AutoavaliacaoGerencialSGQ>> GetAllAtivosAsync()
        {
            return await _context.Set<AutoavaliacaoGerencialSGQ>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }
}
