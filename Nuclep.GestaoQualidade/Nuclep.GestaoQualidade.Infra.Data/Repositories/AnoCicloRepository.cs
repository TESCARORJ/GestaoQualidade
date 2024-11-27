//using Microsoft.AspNetCore.Mvc.Rendering;
//using NHibernate;
//using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
//{
//    public class AnoCicloRepository:BaseRepository<AnoCiclo>, IAnoCicloRepository
//    {
//        private readonly ISession _session;

//        public AnoCicloRepository(ISession session) : base(session)
//        {
//            _session = session;
//        }


//        public IList<AnoCiclo> GetAll()
//        {
//            return this.FindAllAsync().Result.ToList();
//        }

//        public List<SelectListItem> GetAllList()
//        {
//            List<AnoCiclo> lista = GetAll().ToList();

//            var selectList = new List<SelectListItem> {
//                new SelectListItem { Value = "0", Text = "-- SELECIONE --" }
//            };

//            selectList.AddRange(lista.Select(x => new SelectListItem
//            {
//                Value = x.Id.ToString(),
//                Text = $"{x.AnoValue1.ToString()} - {x.AnoValue2.ToString()}"
//            }));

//            return selectList;
//        }

//    }
//}
