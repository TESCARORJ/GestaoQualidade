using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using Nuclep.GestaoQualidade.SqlServer.Contexts;
using System.Linq.Expressions;

namespace Nuclep.GestaoQualidade.SqlServer.Repositories
{
    public class AcaoCorrecaoAvaliadaEficazMetaRepository : BaseRepository<AcaoCorrecaoAvaliadaEficazMeta, long>, IAcaoCorrecaoAvaliadaEficazMetaRepository
    {
        private readonly DataContext _context;
        public AcaoCorrecaoAvaliadaEficazMetaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AcaoCorrecaoAvaliadaEficazMeta?> GetOneAsync(Expression<Func<AcaoCorrecaoAvaliadaEficazMeta, bool>> where)
        {
            return await _context.Set<AcaoCorrecaoAvaliadaEficazMeta>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<AcaoCorrecaoAvaliadaEficazMeta?> GetByIdAsync(long id)
        {
            return await _context.Set<AcaoCorrecaoAvaliadaEficazMeta>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<AcaoCorrecaoAvaliadaEficazMeta>> GetAllAsync()
        {
            return await _context.Set<AcaoCorrecaoAvaliadaEficazMeta>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<AcaoCorrecaoAvaliadaEficazMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<AcaoCorrecaoAvaliadaEficazMeta>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<AcaoCorrecaoAvaliadaEficazMeta>> GetAllAtivosAsync()
        {
            return await _context.Set<AcaoCorrecaoAvaliadaEficazMeta>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }

}
