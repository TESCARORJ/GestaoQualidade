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
    public class CumprimentoVerbaDestinadaPATMMERepository : BaseRepository<CumprimentoVerbaDestinadaPATMME, long>, ICumprimentoVerbaDestinadaPATMMERepository
    {
        private readonly DataContext _context;
        public CumprimentoVerbaDestinadaPATMMERepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CumprimentoVerbaDestinadaPATMME?> GetOneAsync(Expression<Func<CumprimentoVerbaDestinadaPATMME, bool>> where)
        {
            return await _context.Set<CumprimentoVerbaDestinadaPATMME>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<CumprimentoVerbaDestinadaPATMME?> GetByIdAsync(long id)
        {
            return await _context.Set<CumprimentoVerbaDestinadaPATMME>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<CumprimentoVerbaDestinadaPATMME>> GetAllAsync()
        {
            return await _context.Set<CumprimentoVerbaDestinadaPATMME>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<CumprimentoVerbaDestinadaPATMME>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<CumprimentoVerbaDestinadaPATMME>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<CumprimentoVerbaDestinadaPATMME>> GetAllAtivosAsync()
        {
            return await _context.Set<CumprimentoVerbaDestinadaPATMME>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }
}
