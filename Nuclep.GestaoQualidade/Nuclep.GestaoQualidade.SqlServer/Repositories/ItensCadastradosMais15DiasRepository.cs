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
    public class ItensCadastradosMais15DiasRepository : BaseRepository<ItensCadastradosMais15Dias, long>, IItensCadastradosMais15DiasRepository
    {
        private readonly DataContext _context;
        public ItensCadastradosMais15DiasRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ItensCadastradosMais15Dias?> GetOneAsync(Expression<Func<ItensCadastradosMais15Dias, bool>> where) 
        { 
            return await _context.Set<ItensCadastradosMais15Dias>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();    
        }
        
        public async Task<ItensCadastradosMais15Dias?> GetByIdAsync(long id) 
        { 
            return await _context.Set<ItensCadastradosMais15Dias>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ItensCadastradosMais15Dias>> GetAllAsync()
        {
            return await _context.Set<ItensCadastradosMais15Dias>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<ItensCadastradosMais15Dias>?> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<ItensCadastradosMais15Dias>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<ItensCadastradosMais15Dias>> GetAllAtivosAsync()
        {
            return await _context.Set<ItensCadastradosMais15Dias>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }

        public async Task<List<ItensCadastradosMais15Dias>> GetLocalidadeUsarioLogadoAsync(long usuarioLogadoId, long localidadeId)
        {
            return await _context.Set<ItensCadastradosMais15Dias>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


    }
}
