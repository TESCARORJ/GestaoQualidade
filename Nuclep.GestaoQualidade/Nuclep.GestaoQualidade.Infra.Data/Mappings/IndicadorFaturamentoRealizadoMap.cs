using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorFaturamentoRealizadoMap:ClassMap<IndicadorFaturamentoRealizado>
    {
        public IndicadorFaturamentoRealizadoMap()
        {
            Table("IndicadorFaturamentoRealizado");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Trimestre);
            Map(a => a.SomatorioFaturamentoRealizadoTrimestre);
            Map(a => a.PrevistoJaneiroAnoCorrente);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
