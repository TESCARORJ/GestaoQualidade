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
    public class TempoMedioEmissaoOCItensCriticosRepository : BaseRepository<TempoMedioEmissaoOCItensCriticos, long>, ITempoMedioEmissaoOCItensCriticosRepository
    {
        private readonly DataContext _context;
        public TempoMedioEmissaoOCItensCriticosRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TempoMedioEmissaoOCItensCriticos?> GetOneAsync(Expression<Func<TempoMedioEmissaoOCItensCriticos, bool>> where) 
        { 
            return await _context.Set<TempoMedioEmissaoOCItensCriticos>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();    
        }
        
        public async Task<TempoMedioEmissaoOCItensCriticos?> GetByIdAsync(long id) 
        { 
            return await _context.Set<TempoMedioEmissaoOCItensCriticos>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<TempoMedioEmissaoOCItensCriticos>> GetAllAsync()
        {
            return await _context.Set<TempoMedioEmissaoOCItensCriticos>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<TempoMedioEmissaoOCItensCriticos>?> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<TempoMedioEmissaoOCItensCriticos>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<TempoMedioEmissaoOCItensCriticos>> GetAllAtivosAsync()
        {
            return await _context.Set<TempoMedioEmissaoOCItensCriticos>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }

        public async Task<List<TempoMedioEmissaoOCItensCriticos>> GetLocalidadeUsarioLogadoAsync(long usuarioLogadoId, long localidadeId)
        {
            return await _context.Set<TempoMedioEmissaoOCItensCriticos>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


    }
}
