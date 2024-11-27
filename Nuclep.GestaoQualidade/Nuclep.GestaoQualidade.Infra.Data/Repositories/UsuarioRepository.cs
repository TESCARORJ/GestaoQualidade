using Microsoft.AspNetCore.Mvc.Rendering;
using NHibernate;
using NHibernate.Linq;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
{
    public class UsuarioRepository:BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly ISession _session;

        public UsuarioRepository(ISession session) : base(session)
        {
            _session = session;
        }

        //public bool ExisteUsuario(string nome)
        //{
        //    return this.FindAsync(x => x.Nome == nome).Result.OrderBy(x => x.Nome).Any();
        //}

        //public IList<Usuario> GetAllAtivos()
        //{
        //    return this.FindAsync(x => x.IsAtivo == true).Result.OrderBy(x => x.Nome).ToList();
        //}

        //public List<SelectListItem> GetAllAtivosList()
        //{
        //    List<Usuario> lista = GetAllAtivos().OrderBy(x => x.Nome).ToList();

        //    var selectList = new List<SelectListItem> {
        //        new SelectListItem { Value = "0", Text = "-- SELECIONE --" }
        //    };

        //    selectList.AddRange(lista.Select(x => new SelectListItem
        //    {
        //        Value = x.Id.ToString(),
        //        Text = x.Nome
        //    }));

        //    return selectList;
        //}

        //public async Task<Usuario> GetUsuarioByNameAsync(string nome)
        //{
        //    var usuario = await FindAsync(x => x.Nome == nome).Result.FirstOrDefaultAsync();
        //    return usuario;
        //}
    }
}
