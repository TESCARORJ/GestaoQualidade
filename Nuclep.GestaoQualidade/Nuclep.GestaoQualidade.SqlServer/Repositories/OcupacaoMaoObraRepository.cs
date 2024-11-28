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
    public class OcupacaoMaoObraRepository : BaseRepository<OcupacaoMaoObra, long>, IOcupacaoMaoObraRepository
    {
        private readonly DataContext _context;
        public OcupacaoMaoObraRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OcupacaoMaoObra?> GetOneAsync(Expression<Func<OcupacaoMaoObra, bool>> where) 
        { 
            return await _context.Set<OcupacaoMaoObra>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();    
        }
        
        public async Task<OcupacaoMaoObra?> GetByIdAsync(long id) 
        { 
            return await _context.Set<OcupacaoMaoObra>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<OcupacaoMaoObra>> GetAllAsync()
        {
            return await _context.Set<OcupacaoMaoObra>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<OcupacaoMaoObra>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<OcupacaoMaoObra>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<OcupacaoMaoObra>> GetAllAtivosAsync()
        {
            return await _context.Set<OcupacaoMaoObra>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }

        public async Task<List<OcupacaoMaoObra>> GetLocalidadeUsarioLogadoAsync(long usuarioLogadoId, long localidadeId)
        {
            return await _context.Set<OcupacaoMaoObra>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


    }
}
