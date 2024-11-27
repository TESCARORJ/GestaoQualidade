//using Microsoft.AspNetCore.Mvc.Rendering;
//using NHibernate;
//using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
//{
//    public class ItensCadastradosMais15DiasMetaRepository:BaseRepository<ItensCadastradosMais15DiasMeta>, IItensCadastradosMais15DiasMetaRepository
//    {
//        private readonly ISession _session;

//        public ItensCadastradosMais15DiasMetaRepository(ISession session) : base(session)
//        {
//            _session = session;
//        }


//        public IList<ItensCadastradosMais15DiasMeta> GetAllAtivos()
//        {
//            return this.FindAsync(x => x.IsAtivo == true).Result.OrderBy(x => x.Id).ToList();
//        }

//        public List<SelectListItem> GetAllAtivosList()
//        {
//            List<ItensCadastradosMais15DiasMeta> lista = GetAllAtivos().OrderBy(x => x.Id).ToList();

//            var selectList = new List<SelectListItem> {
//                new SelectListItem { Value = "0", Text = "-- SELECIONE --" }
//            };

//            selectList.AddRange(lista.Select(x => new SelectListItem
//            {
//                Value = x.Id.ToString(),
//                Text = $"{x.Meta}"
//            }));

//            return selectList;
//        }

//    }
//}
