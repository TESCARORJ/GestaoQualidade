using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class AderenciaProgramacaoMensalMetaMap : ClassMap<AderenciaProgramacaoMensalMeta>
    {
        public AderenciaProgramacaoMensalMetaMap()
        {
            Table("AderenciaProgramacaoMensalMeta");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
