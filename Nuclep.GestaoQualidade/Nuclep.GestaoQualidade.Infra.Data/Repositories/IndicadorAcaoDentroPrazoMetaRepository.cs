﻿//using Microsoft.AspNetCore.Mvc.Rendering;
//using NHibernate;
//using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
//{
//    public class IndicadorAcaoDentroPrazoMetaRepository:BaseRepository<IndicadorAcaoDentroPrazoMeta>, IIndicadorAcaoDentroPrazoMetaRepository
//    {
//        private readonly ISession _session;

//        public IndicadorAcaoDentroPrazoMetaRepository(ISession session) : base(session)
//        {
//            _session = session;
//        }


//        public IList<IndicadorAcaoDentroPrazoMeta> GetAllAtivos()
//        {
//            return this.FindAsync(x => x.IsAtivo == true).Result.OrderBy(x => x.Id).ToList();
//        }

//        public List<SelectListItem> GetAllAtivosList()
//        {
//            List<IndicadorAcaoDentroPrazoMeta> lista = GetAllAtivos().OrderBy(x => x.Id).ToList();

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
