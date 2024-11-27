using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorAcaoDentroPrazoMap:ClassMap<IndicadorAcaoDentroPrazo>
    {
        public IndicadorAcaoDentroPrazoMap()
        {
            Table("IndicadorAcaoDentroPrazo");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Mes);
            Map(a => a.PacPrazo);
            Map(a => a.TotalPacAberto);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
