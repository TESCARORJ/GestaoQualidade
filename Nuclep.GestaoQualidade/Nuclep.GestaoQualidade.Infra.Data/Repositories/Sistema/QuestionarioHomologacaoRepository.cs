//using NHibernate;
//using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories.Sistema;
//using Nuclep.GestaoQualidade.Domain.Models.Sistema;

//namespace Nuclep.GestaoQualidade.Infra.Data.Repositories.Sistema
//{
//    public class QuestionarioHomologacaoRepository:BaseRepository<QuestionarioHomologacao>, IQuestionarioHomologacaoRepository
//    {
//        private readonly ISession _session;

//        public QuestionarioHomologacaoRepository(ISession session) : base(session)
//        {
//            _session = session;
//        }
//        public IList<QuestionarioHomologacao> GetAllAtivos()
//        {
//            return this.FindAsync(x => x.IsAtivo == true).Result.OrderBy(x => x.Id).ToList();
//        }
//    }
//}
