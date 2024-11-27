using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorReducaoRNCMap:ClassMap<IndicadorReducaoRNC>
    {
        public IndicadorReducaoRNCMap()
        {
            Table("IndicadorReducaoRNC");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Mes);
            Map(a => a.TotalRNC);
            Map(a => a.TotalPecasProduzidas);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
