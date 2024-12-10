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
    public class RespostaAreasRiscosPrazoOriginalMetaRepository : BaseRepository<RespostaAreasRiscosPrazoOriginalMeta, long>, IRespostaAreasRiscosPrazoOriginalMetaRepository
    {
        private readonly DataContext _context;
        public RespostaAreasRiscosPrazoOriginalMetaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RespostaAreasRiscosPrazoOriginalMeta?> GetOneAsync(Expression<Func<RespostaAreasRiscosPrazoOriginalMeta, bool>> where)
        {
            return await _context.Set<RespostaAreasRiscosPrazoOriginalMeta>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<RespostaAreasRiscosPrazoOriginalMeta?> GetByIdAsync(long id)
        {
            return await _context.Set<RespostaAreasRiscosPrazoOriginalMeta>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<RespostaAreasRiscosPrazoOriginalMeta>> GetAllAsync()
        {
            return await _context.Set<RespostaAreasRiscosPrazoOriginalMeta>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<RespostaAreasRiscosPrazoOriginalMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<RespostaAreasRiscosPrazoOriginalMeta>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<RespostaAreasRiscosPrazoOriginalMeta>> GetAllAtivosAsync()
        {
            return await _context.Set<RespostaAreasRiscosPrazoOriginalMeta>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }

}
