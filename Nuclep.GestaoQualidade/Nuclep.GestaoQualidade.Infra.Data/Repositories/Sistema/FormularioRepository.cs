//using Microsoft.AspNetCore.Mvc.Rendering;
//using NHibernate;
//using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories.Sistema;
//using Nuclep.GestaoQualidade.Domain.Models.Sistema;

//namespace Nuclep.GestaoQualidade.Infra.Data.Repositories.Sistema
//{
//    public class FormularioRepository:BaseRepository<Formulario>, IFormularioRepository
//    {
//        private readonly ISession _session;

//        public FormularioRepository(ISession session) : base(session)
//        {
//            _session = session;
//        }


//        public async Task<IList<Formulario>> GetAllAtivos()
//        {
//            return this.FindAsync(x => x.IsAtivo == true).Result.OrderBy(x => x.Nome).ToList();
//        }

//        public async Task<List<SelectListItem>> GetAllAtivosListAsync()
//        {
//            IList<Formulario> lista = await GetAllAtivos();
//            lista = lista.OrderBy(x => x.Id).ToList();

//            var selectList = new List<SelectListItem> {
//                new SelectListItem { Value = "0", Text = "-- SELECIONE --" }
//                };

//            selectList.AddRange(lista.Select(x => new SelectListItem
//            {
//                Value = x.Id.ToString(),
//                Text = x.Nome
//            }));

//            return selectList;
//        }
//    }
//}
