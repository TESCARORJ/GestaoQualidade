//using FluentNHibernate.Mapping;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.SqlServer.Mappings
//{
//    public class TempoReparoEquipamentosProgramadosObrasMetaMap : ClassMap<TempoReparoEquipamentosProgramadosObrasMeta>
//    {
//        public TempoReparoEquipamentosProgramadosObrasMetaMap()
//        {
//            Table("TempoReparoEquipamentosProgramadosObrasMeta");

//            Id(a => a.Id);
  
//            Map(a => a.IsAtivo);
//            Map(a => a.DataHoraCadastro);
//            Map(a => a.Meta);

//            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

//        }
//    }
//}
