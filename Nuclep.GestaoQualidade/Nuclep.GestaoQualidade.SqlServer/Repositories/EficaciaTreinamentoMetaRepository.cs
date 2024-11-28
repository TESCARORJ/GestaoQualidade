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
    public class EficaciaTreinamentoMetaRepository : BaseRepository<EficaciaTreinamentoMeta, long>, IEficaciaTreinamentoMetaRepository
    {
        private readonly DataContext _context;
        public EficaciaTreinamentoMetaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<EficaciaTreinamentoMeta?> GetOneAsync(Expression<Func<EficaciaTreinamentoMeta, bool>> where)
        {
            return await _context.Set<EficaciaTreinamentoMeta>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<EficaciaTreinamentoMeta?> GetByIdAsync(long id)
        {
            return await _context.Set<EficaciaTreinamentoMeta>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<EficaciaTreinamentoMeta>> GetAllAsync()
        {
            return await _context.Set<EficaciaTreinamentoMeta>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<EficaciaTreinamentoMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<EficaciaTreinamentoMeta>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<EficaciaTreinamentoMeta>> GetAllAtivosAsync()
        {
            return await _context.Set<EficaciaTreinamentoMeta>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }

}
