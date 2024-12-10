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
    public class ServiceLevelAgreementMetaRepository : BaseRepository<ServiceLevelAgreementMeta, long>, IServiceLevelAgreementMetaRepository
    {
        private readonly DataContext _context;
        public ServiceLevelAgreementMetaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ServiceLevelAgreementMeta?> GetOneAsync(Expression<Func<ServiceLevelAgreementMeta, bool>> where)
        {
            return await _context.Set<ServiceLevelAgreementMeta>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();
        }

        public async Task<ServiceLevelAgreementMeta?> GetByIdAsync(long id)
        {
            return await _context.Set<ServiceLevelAgreementMeta>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ServiceLevelAgreementMeta>> GetAllAsync()
        {
            try
            {
                var resultado = await _context.Set<ServiceLevelAgreementMeta>()
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
        public async Task<List<ServiceLevelAgreementMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<ServiceLevelAgreementMeta>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<ServiceLevelAgreementMeta>> GetAllAtivosAsync()
        {
            return await _context.Set<ServiceLevelAgreementMeta>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
    }

}
