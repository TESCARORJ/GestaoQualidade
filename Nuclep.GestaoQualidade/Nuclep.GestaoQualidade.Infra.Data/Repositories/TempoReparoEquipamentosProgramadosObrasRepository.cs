﻿//using Microsoft.AspNetCore.Mvc.Rendering;
//using NHibernate;
//using Nuclep.GestaoQualidade.Domain.Enumeradores;
//using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
//{
//    public class TempoReparoEquipamentosProgramadosObrasRepository : BaseRepository<TempoReparoEquipamentosProgramadosObras>, ITempoReparoEquipamentosProgramadosObrasRepository
//    {
//        private readonly ISession _session;
//        private readonly ILogCrudRepository _logCrudRepository;
//        private readonly ILogTabelaRepository _logTabelaRepository;

//        public TempoReparoEquipamentosProgramadosObrasRepository(ISession session, ILogCrudRepository logCrudRepository, ILogTabelaRepository logTabelaRepository) : base(session)
//        {
//            _session = session;
//            _logCrudRepository = logCrudRepository;
//            _logTabelaRepository = logTabelaRepository;
//        }


//        public IList<TempoReparoEquipamentosProgramadosObras> GetAllAtivos()
//        {
//            return this.FindAsync(x => x.Id > 0).Result.OrderBy(x => x.Id).ToList();
//        }

//        public List<SelectListItem> GetAllAtivosList()
//        {
//            List<TempoReparoEquipamentosProgramadosObras> lista = GetAllAtivos().OrderBy(x => x.Id).ToList();

//            var selectList = new List<SelectListItem> {
//                new SelectListItem { Value = "0", Text = "-- SELECIONE --" }
//            };

//            selectList.AddRange(lista.Select(x => new SelectListItem
//            {
//                Value = x.Id.ToString(),
//                Text = $"{x.Mes} - {x.Ano}"
//            }));

//            return selectList;
//        }

//    }
//}