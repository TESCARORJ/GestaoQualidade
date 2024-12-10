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
    public class ItensCadastradosMais15DiasMetaRepository : BaseRepository<ItensCadastradosMais15DiasMeta, long>, IItensCadastradosMais15DiasMetaRepository
    {
        private readonly DataContext _context;
        public ItensCadastradosMais15DiasMetaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ItensCadastradosMais15DiasMeta?> GetOneAsync(Expression<Func<ItensCadastradosMais15DiasMeta, bool>> where)
        {
            return await _context.Set<ItensCadastradosMais15DiasMeta>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<ItensCadastradosMais15DiasMeta?> GetByIdAsync(long id)
        {
            return await _context.Set<ItensCadastradosMais15DiasMeta>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ItensCadastradosMais15DiasMeta>> GetAllAsync()
        {
            try
            {
                var resultado = await _context.Set<ItensCadastradosMais15DiasMeta>()
                              .Where(x => x.Id > 0)
                              .Include(x => x.UsuarioCadastro)
                              .ToListAsync();
                return resultado;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<List<ItensCadastradosMais15DiasMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<ItensCadastradosMais15DiasMeta>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<ItensCadastradosMais15DiasMeta>> GetAllAtivosAsync()
        {
            return await _context.Set<ItensCadastradosMais15DiasMeta>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }

}
