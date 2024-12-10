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
    public class SatisfacaoUsuarioRepository : BaseRepository<SatisfacaoUsuario, long>, ISatisfacaoUsuarioRepository
    {
        private readonly DataContext _context;
        public SatisfacaoUsuarioRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SatisfacaoUsuario?> GetOneAsync(Expression<Func<SatisfacaoUsuario, bool>> where) 
        { 
            return await _context.Set<SatisfacaoUsuario>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();    
        }
        
        public async Task<SatisfacaoUsuario?> GetByIdAsync(long id) 
        { 
            return await _context.Set<SatisfacaoUsuario>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<SatisfacaoUsuario>> GetAllAsync()
        {
            return await _context.Set<SatisfacaoUsuario>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<SatisfacaoUsuario>?> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<SatisfacaoUsuario>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<SatisfacaoUsuario>> GetAllAtivosAsync()
        {
            return await _context.Set<SatisfacaoUsuario>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }

        public async Task<List<SatisfacaoUsuario>> GetLocalidadeUsarioLogadoAsync(long usuarioLogadoId, long localidadeId)
        {
            return await _context.Set<SatisfacaoUsuario>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


    }
}
