﻿//using Microsoft.AspNetCore.Mvc.Rendering;
//using NHibernate;
//using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.Infra.Data.Repositories
//{
//    public class IndicadorGestaoProcessosPessoasPrevistoPATMetaRepository:BaseRepository<IndicadorGestaoProcessosPessoasPrevistoPATMeta>, IIndicadorGestaoProcessosPessoasPrevistoPATMetaRepository
//    {
//        private readonly ISession _session;

//        public IndicadorGestaoProcessosPessoasPrevistoPATMetaRepository(ISession session) : base(session)
//        {
//            _session = session;
//        }


//        public IList<IndicadorGestaoProcessosPessoasPrevistoPATMeta> GetAllAtivos()
//        {
//            return this.FindAsync(x => x.IsAtivo == true).Result.OrderBy(x => x.Id).ToList();
//        }

       

//    }
//}