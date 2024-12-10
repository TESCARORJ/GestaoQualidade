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
    public class TempoReparoEquipamentosProgramadosObrasRepository : BaseRepository<TempoReparoEquipamentosProgramadosObras, long>, ITempoReparoEquipamentosProgramadosObrasRepository
    {
        private readonly DataContext _context;
        public TempoReparoEquipamentosProgramadosObrasRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TempoReparoEquipamentosProgramadosObras?> GetOneAsync(Expression<Func<TempoReparoEquipamentosProgramadosObras, bool>> where) 
        { 
            return await _context.Set<TempoReparoEquipamentosProgramadosObras>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();    
        }
        
        public async Task<TempoReparoEquipamentosProgramadosObras?> GetByIdAsync(long id) 
        { 
            return await _context.Set<TempoReparoEquipamentosProgramadosObras>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<TempoReparoEquipamentosProgramadosObras>> GetAllAsync()
        {
            return await _context.Set<TempoReparoEquipamentosProgramadosObras>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<TempoReparoEquipamentosProgramadosObras>?> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<TempoReparoEquipamentosProgramadosObras>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<TempoReparoEquipamentosProgramadosObras>> GetAllAtivosAsync()
        {
            return await _context.Set<TempoReparoEquipamentosProgramadosObras>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }

        public async Task<List<TempoReparoEquipamentosProgramadosObras>> GetLocalidadeUsarioLogadoAsync(long usuarioLogadoId, long localidadeId)
        {
            return await _context.Set<TempoReparoEquipamentosProgramadosObras>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


    }
}
