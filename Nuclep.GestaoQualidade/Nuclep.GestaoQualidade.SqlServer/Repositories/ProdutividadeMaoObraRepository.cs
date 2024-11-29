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
    public class ProdutividadeMaoObraRepository : BaseRepository<ProdutividadeMaoObra, long>, IProdutividadeMaoObraRepository
    {
        private readonly DataContext _context;
        public ProdutividadeMaoObraRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProdutividadeMaoObra?> GetOneAsync(Expression<Func<ProdutividadeMaoObra, bool>> where) 
        { 
            return await _context.Set<ProdutividadeMaoObra>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();    
        }
        
        public async Task<ProdutividadeMaoObra?> GetByIdAsync(long id) 
        { 
            return await _context.Set<ProdutividadeMaoObra>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ProdutividadeMaoObra>> GetAllAsync()
        {
            return await _context.Set<ProdutividadeMaoObra>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<ProdutividadeMaoObra>?> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<ProdutividadeMaoObra>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<ProdutividadeMaoObra>> GetAllAtivosAsync()
        {
            return await _context.Set<ProdutividadeMaoObra>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }

        public async Task<List<ProdutividadeMaoObra>> GetLocalidadeUsarioLogadoAsync(long usuarioLogadoId, long localidadeId)
        {
            return await _context.Set<ProdutividadeMaoObra>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


    }
}
