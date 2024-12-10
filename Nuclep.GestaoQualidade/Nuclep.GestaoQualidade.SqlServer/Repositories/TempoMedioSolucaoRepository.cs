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
    public class TempoMedioSolucaoRepository : BaseRepository<TempoMedioSolucao, long>, ITempoMedioSolucaoRepository
    {
        private readonly DataContext _context;
        public TempoMedioSolucaoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TempoMedioSolucao?> GetOneAsync(Expression<Func<TempoMedioSolucao, bool>> where) 
        { 
            return await _context.Set<TempoMedioSolucao>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();    
        }
        
        public async Task<TempoMedioSolucao?> GetByIdAsync(long id) 
        { 
            return await _context.Set<TempoMedioSolucao>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<TempoMedioSolucao>> GetAllAsync()
        {
            return await _context.Set<TempoMedioSolucao>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<TempoMedioSolucao>?> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<TempoMedioSolucao>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<TempoMedioSolucao>> GetAllAtivosAsync()
        {
            return await _context.Set<TempoMedioSolucao>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }

        public async Task<List<TempoMedioSolucao>> GetLocalidadeUsarioLogadoAsync(long usuarioLogadoId, long localidadeId)
        {
            return await _context.Set<TempoMedioSolucao>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


    }
}
