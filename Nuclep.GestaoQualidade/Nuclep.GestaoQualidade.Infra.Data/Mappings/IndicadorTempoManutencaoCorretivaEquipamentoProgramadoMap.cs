using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorTempoManutencaoCorretivaEquipamentoProgramadoMap:ClassMap<IndicadorTempoManutencaoCorretivaEquipamentoProgramado>
    {
        public IndicadorTempoManutencaoCorretivaEquipamentoProgramadoMap()
        {
            Table("IndicadorTempoManutencaoCorretivaEquipamentoProgramado");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Mes);
            Map(a => a.TotalHorasManutencaoCorretivaEquipamentosProgramados);
            Map(a => a.TotalHorasManutencaoPreventivaRealizada);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
