using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorSatisfacaoClientesAreaResponsavelMap:ClassMap<IndicadorSatisfacaoClientesAreaResponsavel>
    {
        public IndicadorSatisfacaoClientesAreaResponsavelMap()
        {
            Table("IndicadorSatisfacaoClientesAreaResponsavel");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Realizado);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
