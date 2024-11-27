//using FluentNHibernate.Mapping;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.SqlServer.Mappings
//{
//    public class TempoMedioSolucaoMap:ClassMap<TempoMedioSolucao>
//    {
//        public TempoMedioSolucaoMap()
//        {
//            Table("TempoMedioSolucao");

//            Id(a => a.Id);
  
//            Map(a => a.IsAtivo);
//            Map(a => a.DataHoraCadastro);
//            Map(a => a.Ano);
//            Map(a => a.Mes);
//            Map(a => a.Atividade1);
//            Map(a => a.Atividade2);
//            Map(a => a.Meta);

//            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

//        }
//    }
//}
