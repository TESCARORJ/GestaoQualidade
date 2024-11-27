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
    public class CumprimentoEtapasPACDentroPrazoMetaRepository : BaseRepository<CumprimentoEtapasPACDentroPrazoMeta, long>, ICumprimentoEtapasPACDentroPrazoMetaRepository
    {
        private readonly DataContext _context;
        public CumprimentoEtapasPACDentroPrazoMetaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CumprimentoEtapasPACDentroPrazoMeta?> GetOneAsync(Expression<Func<CumprimentoEtapasPACDentroPrazoMeta, bool>> where)
        {
            return await _context.Set<CumprimentoEtapasPACDentroPrazoMeta>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<CumprimentoEtapasPACDentroPrazoMeta?> GetByIdAsync(long id)
        {
            return await _context.Set<CumprimentoEtapasPACDentroPrazoMeta>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<CumprimentoEtapasPACDentroPrazoMeta>> GetAllAsync()
        {
            return await _context.Set<CumprimentoEtapasPACDentroPrazoMeta>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<CumprimentoEtapasPACDentroPrazoMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<CumprimentoEtapasPACDentroPrazoMeta>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<CumprimentoEtapasPACDentroPrazoMeta>> GetAllAtivosAsync()
        {
            return await _context.Set<CumprimentoEtapasPACDentroPrazoMeta>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }

}
