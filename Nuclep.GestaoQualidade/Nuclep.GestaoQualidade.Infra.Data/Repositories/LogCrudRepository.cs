using NHibernate;
using NHibernate.Criterion;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
{
    public class LogCrudRepository:BaseRepository<LogCrud>, ILogCrudRepository
    {
        private readonly ISession _session;

        public LogCrudRepository(ISession session) : base(session)
        {
            _session = session;
        }

        //public async Task SalvarAsync(IList<LogCrud> entities, long IdRef)
        //{
        //    foreach (var o in entities)
        //    {
        //        o.IdReferencia = IdRef;
        //    }

            

        //    this.SaveAsync(entities);
        //}

        //public async Task SalvarAsync(IList<LogCrud> entities)
        //{
        //    this.SaveAsync(entities);
        //}

        public async Task<List<LogCrud>> GetByFilterAsync(long usuarioId, DateTime? dataInicio, DateTime? dataFim, long tabelaId, long referenciaId)
        {
            var criteria = _session.CreateCriteria<LogCrud>();

            if (usuarioId > 0)
                criteria.Add(Restrictions.Eq("Usuario.Id", usuarioId));

            if (dataInicio != null && dataFim != null)
            {
                var start = DateTime.Parse($"{dataInicio.Value.ToShortDateString()} 00:00");
                var end = DateTime.Parse($"{dataFim.Value.ToShortDateString()} 23:59");
                criteria.Add(Restrictions.Between("Data", start, end));
            }

            if (tabelaId > 0)
                criteria.Add(Restrictions.Eq("LogTabela.Id", tabelaId));

            if (referenciaId > 0)
                criteria.Add(Restrictions.Eq("IdReferencia", referenciaId));


            var result = await criteria.ListAsync<LogCrud>();
            return result.OrderBy(x => x.DataHoraCadastro).ToList();
        }
    }
}
