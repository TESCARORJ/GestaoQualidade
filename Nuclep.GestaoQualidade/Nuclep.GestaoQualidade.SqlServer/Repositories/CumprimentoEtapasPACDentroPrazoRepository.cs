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
    public class CumprimentoEtapasPACDentroPrazoRepository : BaseRepository<CumprimentoEtapasPACDentroPrazo, long>, ICumprimentoEtapasPACDentroPrazoRepository
    {
        private readonly DataContext _context;
        public CumprimentoEtapasPACDentroPrazoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CumprimentoEtapasPACDentroPrazo?> GetOneAsync(Expression<Func<CumprimentoEtapasPACDentroPrazo, bool>> where)
        {
            return await _context.Set<CumprimentoEtapasPACDentroPrazo>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<CumprimentoEtapasPACDentroPrazo?> GetByIdAsync(long id)
        {
            return await _context.Set<CumprimentoEtapasPACDentroPrazo>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<CumprimentoEtapasPACDentroPrazo>> GetAllAsync()
        {
            return await _context.Set<CumprimentoEtapasPACDentroPrazo>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<CumprimentoEtapasPACDentroPrazo>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<CumprimentoEtapasPACDentroPrazo>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<CumprimentoEtapasPACDentroPrazo>> GetAllAtivosAsync()
        {
            return await _context.Set<CumprimentoEtapasPACDentroPrazo>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }
}
