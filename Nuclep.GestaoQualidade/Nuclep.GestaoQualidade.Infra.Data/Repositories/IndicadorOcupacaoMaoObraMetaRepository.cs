//using Microsoft.AspNetCore.Mvc.Rendering;
//using NHibernate;
//using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
//{
//    public class IndicadorOcupacaoMaoObraMetaRepository:BaseRepository<IndicadorOcupacaoMaoObraMeta>, IIndicadorOcupacaoMaoObraMetaRepository
//    {
//        private readonly ISession _session;

//        public IndicadorOcupacaoMaoObraMetaRepository(ISession session) : base(session)
//        {
//            _session = session;
//        }


//        public IList<IndicadorOcupacaoMaoObraMeta> GetAllAtivos()
//        {
//            return this.FindAsync(x => x.IsAtivo == true).Result.OrderBy(x => x.Id).ToList();
//        }

      

//    }
//}
