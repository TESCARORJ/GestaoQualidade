using Microsoft.AspNetCore.Mvc.Rendering;
using NHibernate;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
{
    public class AderenciaProgramacaoMensalRepository : BaseRepository<AderenciaProgramacaoMensal>, IAderenciaProgramacaoMensalRepository
    {
        private readonly ISession _session;
       

        public AderenciaProgramacaoMensalRepository(ISession session, ILogCrudRepository logCrudRepository, ILogTabelaRepository logTabelaRepository) : base(session)
        {
            _session = session;
        }
    }
}
