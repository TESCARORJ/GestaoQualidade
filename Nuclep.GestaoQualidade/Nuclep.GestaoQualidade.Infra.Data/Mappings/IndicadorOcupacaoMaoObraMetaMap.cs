using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorOcupacaoMaoObraMetaMap : ClassMap<IndicadorOcupacaoMaoObraMeta>
    {
        public IndicadorOcupacaoMaoObraMetaMap()
        {
            Table("IndicadorOcupacaoMaoObraMeta");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Meta);
            Map(a => a.MetaDesafiadora);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
