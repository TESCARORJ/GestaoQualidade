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
    public class LocalidadeRepository : BaseRepository<Localidade, long>, ILocalidadeRepository
    {
        private readonly DataContext _context;
        public LocalidadeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Localidade?> GetOneAsync(Expression<Func<Localidade, bool>> where)
        {
            return await _context.Set<Localidade>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<Localidade?> GetByIdAsync(long id)
        {
            return await _context.Set<Localidade>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Localidade>> GetAllAsync()
        {
            return await _context.Set<Localidade>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<Localidade>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<Localidade>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<Localidade>> GetAllAtivosAsync()
        {
            return await _context.Set<Localidade>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }
}
