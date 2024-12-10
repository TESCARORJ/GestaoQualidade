﻿using Microsoft.EntityFrameworkCore;
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
    public class TempoMedioEmissaoOCItensCriticosMetaRepository : BaseRepository<TempoMedioEmissaoOCItensCriticosMeta, long>, ITempoMedioEmissaoOCItensCriticosMetaRepository
    {
        private readonly DataContext _context;
        public TempoMedioEmissaoOCItensCriticosMetaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TempoMedioEmissaoOCItensCriticosMeta?> GetOneAsync(Expression<Func<TempoMedioEmissaoOCItensCriticosMeta, bool>> where)
        {
            return await _context.Set<TempoMedioEmissaoOCItensCriticosMeta>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<TempoMedioEmissaoOCItensCriticosMeta?> GetByIdAsync(long id)
        {
            return await _context.Set<TempoMedioEmissaoOCItensCriticosMeta>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<TempoMedioEmissaoOCItensCriticosMeta>> GetAllAsync()
        {
            return await _context.Set<TempoMedioEmissaoOCItensCriticosMeta>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<TempoMedioEmissaoOCItensCriticosMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<TempoMedioEmissaoOCItensCriticosMeta>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<TempoMedioEmissaoOCItensCriticosMeta>> GetAllAtivosAsync()
        {
            return await _context.Set<TempoMedioEmissaoOCItensCriticosMeta>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }

}
