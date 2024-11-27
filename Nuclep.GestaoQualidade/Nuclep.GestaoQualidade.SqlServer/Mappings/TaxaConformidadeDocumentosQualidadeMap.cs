//using FluentNHibernate.Mapping;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.SqlServer.Mappings
//{
//    public class TaxaConformidadeDocumentosQualidadeMap:ClassMap<TaxaConformidadeDocumentosQualidade>
//    {
//        public TaxaConformidadeDocumentosQualidadeMap()
//        {
//            Table("TaxaConformidadeDocumentosQualidade");

//            Id(a => a.Id);
  
//            Map(a => a.IsAtivo);
//            Map(a => a.DataHoraCadastro);
//            Map(a => a.Ciclo);
//            Map(a => a.Realizado);
//            Map(a => a.Meta);

//            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

//        }
//    }
//}
