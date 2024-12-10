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
    public class SatisfacaoUsuarioMetaRepository : BaseRepository<SatisfacaoUsuarioMeta, long>, ISatisfacaoUsuarioMetaRepository
    {
        private readonly DataContext _context;
        public SatisfacaoUsuarioMetaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SatisfacaoUsuarioMeta?> GetOneAsync(Expression<Func<SatisfacaoUsuarioMeta, bool>> where)
        {
            return await _context.Set<SatisfacaoUsuarioMeta>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<SatisfacaoUsuarioMeta?> GetByIdAsync(long id)
        {
            return await _context.Set<SatisfacaoUsuarioMeta>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<SatisfacaoUsuarioMeta>> GetAllAsync()
        {
            try
            {
                var resultado = await _context.Set<SatisfacaoUsuarioMeta>()
                              .Where(x => x.Id > 0)
                              .Include(x => x.UsuarioCadastro)
                              .ToListAsync();
                return resultado;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public async Task<List<SatisfacaoUsuarioMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<SatisfacaoUsuarioMeta>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<SatisfacaoUsuarioMeta>> GetAllAtivosAsync()
        {
            return await _context.Set<SatisfacaoUsuarioMeta>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }

}
