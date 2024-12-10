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
    public class ServiceLevelAgreementRepository : BaseRepository<ServiceLevelAgreement, long>, IServiceLevelAgreementRepository
    {
        private readonly DataContext _context;
        public ServiceLevelAgreementRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ServiceLevelAgreement?> GetOneAsync(Expression<Func<ServiceLevelAgreement, bool>> where) 
        { 
            return await _context.Set<ServiceLevelAgreement>()
                                 .Where(where)
                                 .Include(x => x.UsuarioCadastro)
                                 .FirstOrDefaultAsync();    
        }
        
        public async Task<ServiceLevelAgreement?> GetByIdAsync(long id) 
        { 
            return await _context.Set<ServiceLevelAgreement>()
                                 .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<ServiceLevelAgreement>> GetAllAsync()
        {
            return await _context.Set<ServiceLevelAgreement>()
                                 .Where(x => x.Id > 0)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }
        public async Task<List<ServiceLevelAgreement>?> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            return await _context.Set<ServiceLevelAgreement>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


        public async Task<List<ServiceLevelAgreement>> GetAllAtivosAsync()
        {
            return await _context.Set<ServiceLevelAgreement>()
                                 .Where(x => x.Id > 0 && x.IsAtivo == true)
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }

        public async Task<List<ServiceLevelAgreement>> GetLocalidadeUsarioLogadoAsync(long usuarioLogadoId, long localidadeId)
        {
            return await _context.Set<ServiceLevelAgreement>()
                                 .Where(x => x.Id > 0 && x.UsuarioCadastroId == usuarioLogadoId)
                                 .AsNoTracking()
                                 .Include(x => x.UsuarioCadastro)
                                 .ToListAsync();
        }


    }
}
