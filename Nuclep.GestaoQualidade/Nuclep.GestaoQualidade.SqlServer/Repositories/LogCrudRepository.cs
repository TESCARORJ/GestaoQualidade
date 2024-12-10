using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using Nuclep.GestaoQualidade.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.SqlServer.Repositories
{
    public class LogCrudRepository : BaseRepository<LogCrud, long>, ILogCrudRepository
    {
        private readonly DataContext _dataContext;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public LogCrudRepository(DataContext context, DataContext dataContext, ILogTabelaRepository logTabelaRepository, IUsuarioRepository usuarioRepository) : base(context)
        {
            _dataContext = dataContext;
            _logTabelaRepository = logTabelaRepository;
            _usuarioRepository = usuarioRepository;
        }


        public async Task AddAsync(LogCrud entity)
        {
            try
            {
                LogCrud logCrud = new LogCrud
                {
                    IdReferencia = entity.IdReferencia,
                    LogTipo = entity.LogTipo,
                    LogTabelaId = entity.LogTabelaId,
                    LogTabelaNome = entity.LogTabelaNome,
                    UsuarioId = entity.UsuarioId,
                    UsuarioNome = entity.UsuarioNome,
                    Descricao = entity.Descricao,
                    DataHoraCadastro = entity.DataHoraCadastro
                };

                await _dataContext.AddAsync(logCrud);
                await _dataContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<LogCrud>> GetAll()
        {            
            var result =  await _dataContext.Set<LogCrud>().ToListAsync();
            return result;
        }
    }
}
