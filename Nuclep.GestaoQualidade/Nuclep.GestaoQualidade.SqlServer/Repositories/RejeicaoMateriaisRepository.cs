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
    public class RejeicaoMateriaisRepository : BaseRepository<RejeicaoMateriais, long>, IRejeicaoMateriaisRepository
    {
        private readonly DataContext _context;
        public RejeicaoMateriaisRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RejeicaoMateriais?> GetOneAsync(Expression<Func<RejeicaoMateriais, bool>> where)
        {
            return await _context.Set<RejeicaoMateriais>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<RejeicaoMateriais?> GetByIdAsync(long id)
        {
            return await _context.Set<RejeicaoMateriais>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<RejeicaoMateriais>> GetAllAsync()
        {
            return await _context.Set<RejeicaoMateriais>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<RejeicaoMateriais>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<RejeicaoMateriais>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<RejeicaoMateriais>> GetAllAtivosAsync()
        {
            return await _context.Set<RejeicaoMateriais>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }
}
