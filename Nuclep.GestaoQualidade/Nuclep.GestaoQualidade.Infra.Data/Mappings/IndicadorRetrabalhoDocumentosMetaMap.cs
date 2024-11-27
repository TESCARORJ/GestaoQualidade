using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorRetrabalhoDocumentosMetaMap : ClassMap<IndicadorRetrabalhoDocumentosMeta>
    {
        public IndicadorRetrabalhoDocumentosMetaMap()
        {
            Table("IndicadorRetrabalhoDocumentosMeta");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
