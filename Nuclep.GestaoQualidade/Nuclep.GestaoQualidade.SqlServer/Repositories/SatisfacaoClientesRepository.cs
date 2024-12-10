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
    public class SatisfacaoClientesRepository : BaseRepository<SatisfacaoClientes, long>, ISatisfacaoClientesRepository
    {
        private readonly DataContext _context;
        public SatisfacaoClientesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SatisfacaoClientes?> GetOneAsync(Expression<Func<SatisfacaoClientes, bool>> where) 
        { 
            return await _context.Set<SatisfacaoClientes>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();    
        }
        
        public async Task<SatisfacaoClientes?> GetByIdAsync(long id) 
        { 
            return await _context.Set<SatisfacaoClientes>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<SatisfacaoClientes>> GetAllAsync()
        {
            return await _context.Set<SatisfacaoClientes>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<SatisfacaoClientes>?> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<SatisfacaoClientes>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<SatisfacaoClientes>> GetAllAtivosAsync()
        {
            return await _context.Set<SatisfacaoClientes>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }

        public async Task<List<SatisfacaoClientes>> GetLocalidadeUsarioLogadoAsync(long usuarioLogadoId, long localidadeId)
        {
            return await _context.Set<SatisfacaoClientes>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


    }
}
