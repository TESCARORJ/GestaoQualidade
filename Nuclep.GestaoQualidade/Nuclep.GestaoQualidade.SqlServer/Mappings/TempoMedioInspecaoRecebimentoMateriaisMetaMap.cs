﻿//using FluentNHibernate.Mapping;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.SqlServer.Mappings
//{
//    public class TempoMedioInspecaoRecebimentoMateriaisMetaMap : ClassMap<TempoMedioInspecaoRecebimentoMateriaisMeta>
//    {
//        public TempoMedioInspecaoRecebimentoMateriaisMetaMap()
//        {
//            Table("TempoMedioInspecaoRecebimentoMateriaisMeta");

//            Id(a => a.Id);
  
//            Map(a => a.IsAtivo);
//            Map(a => a.DataHoraCadastro);
//            Map(a => a.Meta);

//            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

//        }
//    }
//}
