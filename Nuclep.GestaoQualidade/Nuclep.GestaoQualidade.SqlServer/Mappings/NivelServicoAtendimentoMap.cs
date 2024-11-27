//using FluentNHibernate.Mapping;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.SqlServer.Mappings
//{
//    public class NivelServicoAtendimentoMap:ClassMap<NivelServicoAtendimento>
//    {
//        public NivelServicoAtendimentoMap()
//        {
//            Table("NivelServicoAtendimento");

//            Id(a => a.Id);
  
//            Map(a => a.IsAtivo);
//            Map(a => a.DataHoraCadastro);
//            Map(a => a.Ano);
//            Map(a => a.Mes);
//            Map(a => a.TotalDefeitosSoldaEncontradosEnsaiados);
//            Map(a => a.TotalComprimentoSoldadoInspecionado);
//            Map(a => a.Meta);

//            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

//        }
//    }
//}
