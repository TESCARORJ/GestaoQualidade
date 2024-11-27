//using FluentNHibernate.Mapping;
//using Nuclep.GestaoQualidade.Domain.Models;

//namespace Nuclep.GestaoQualidade.SqlServer.Mappings
//{
//    public class ItensCadastradosMais15DiasMetaMap : ClassMap<ItensCadastradosMais15DiasMeta>
//    {
//        public ItensCadastradosMais15DiasMetaMap()
//        {
//            Table("ItensCadastradosMais15DiasMeta");

//            Id(a => a.Id);
  
//            Map(a => a.IsAtivo);
//            Map(a => a.DataHoraCadastro);
//            Map(a => a.Meta);

//            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

//        }
//    }
//}
