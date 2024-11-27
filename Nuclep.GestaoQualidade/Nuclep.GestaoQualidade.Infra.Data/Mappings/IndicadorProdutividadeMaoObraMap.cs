using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorProdutividadeMaoObraMap:ClassMap<IndicadorProdutividadeMaoObra>
    {
        public IndicadorProdutividadeMaoObraMap()
        {
            Table("IndicadorProdutividadeMaoObra");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Mes);
            Map(a => a.TempoTotalFaturavel);
            Map(a => a.Perdas);
            Map(a => a.TempoDisponivelTotal);
            Map(a => a.Meta);
            Map(a => a.MetaDesafiadora);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
