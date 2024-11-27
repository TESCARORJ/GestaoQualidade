//using Microsoft.AspNetCore.Mvc.Rendering;
//using NHibernate;
//using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
//{
//    public class LocalidadeRepository:BaseRepository<Localidade>, ILocalidadeRepository
//    {
//        private readonly ISession _session;

//        public LocalidadeRepository(ISession session) : base(session)
//        {
//            _session = session;
//        }


//        public IList<Localidade> GetAllAtivos()
//        {
//            return this.FindAsync(x => x.IsAtivo == true).Result.OrderBy(x => x.Nome).ToList();
//        }

//        public List<SelectListItem> GetAllAtivosList()
//        {
//            List<Localidade> lista = GetAllAtivos().OrderBy(x => x.Nome).ToList();

//            var selectList = new List<SelectListItem> {
//                new SelectListItem { Value = "0", Text = "-- SELECIONE --" }
//            };

//            selectList.AddRange(lista.Select(x => new SelectListItem
//            {
//                Value = x.Id.ToString(),
//                Text = x.Nome
//            }));

//            return selectList;
//        }

//    }
//}
