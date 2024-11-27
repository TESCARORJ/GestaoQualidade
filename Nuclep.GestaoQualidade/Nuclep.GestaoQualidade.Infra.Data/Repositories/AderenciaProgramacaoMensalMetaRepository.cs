using Microsoft.AspNetCore.Mvc.Rendering;
using NHibernate;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
{
    public class AderenciaProgramacaoMensalMetaRepository:BaseRepository<AderenciaProgramacaoMensalMeta>, IAderenciaProgramacaoMensalMetaRepository
    {
        private readonly ISession _session;

        public AderenciaProgramacaoMensalMetaRepository(ISession session) : base(session)
        {
            _session = session;
        }
    }
}
