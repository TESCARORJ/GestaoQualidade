//using Microsoft.AspNetCore.Mvc.Rendering;
//using NHibernate;
//using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
//{
//    public class AnoIndiceRepository:BaseRepository<AnoIndice>, IAnoIndiceRepository
//    {
//        private readonly ISession _session;

//        public AnoIndiceRepository(ISession session) : base(session)
//        {
//            _session = session;
//        }


//        public IList<AnoIndice> GetAll()
//        {
//            return this.FindAllAsync().Result.ToList();
//        }

//        public List<SelectListItem> GetAllList()
//        {
//            List<AnoIndice> lista = GetAll().ToList();

//            var selectList = new List<SelectListItem> {
//                new SelectListItem { Value = "0", Text = "-- SELECIONE --" }
//            };

//            selectList.AddRange(lista.Select(x => new SelectListItem
//            {
//                Value = x.Id.ToString(),
//                Text = x.AnoValue.ToString()
//            }));

//            return selectList;
//        }

//    }
//}
