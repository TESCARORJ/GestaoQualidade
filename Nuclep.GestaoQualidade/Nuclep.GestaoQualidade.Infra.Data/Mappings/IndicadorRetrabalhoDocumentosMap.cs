using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorRetrabalhoDocumentosMap:ClassMap<IndicadorRetrabalhoDocumentos>
    {
        public IndicadorRetrabalhoDocumentosMap()
        {
            Table("IndicadorRetrabalhoDocumentos");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Mes);
            Map(a => a.DevRev);
            Map(a => a.DevTotal);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
