using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorAutoavaliacaoGerencialSGQMetaMap : ClassMap<IndicadorAutoavaliacaoGerencialSGQMeta>
    {
        public IndicadorAutoavaliacaoGerencialSGQMetaMap()
        {
            Table("IndicadorAutoavaliacaoGerencialSGQMeta");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
