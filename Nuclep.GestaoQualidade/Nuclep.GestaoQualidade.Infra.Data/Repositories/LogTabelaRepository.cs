using NHibernate;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
{
    public class LogTabelaRepository:BaseRepository<LogTabela>, ILogTabelaRepository
    {
        private readonly ISession _session;

        public LogTabelaRepository(ISession session) : base(session)
        {
            _session = session;
        }
    }
}
