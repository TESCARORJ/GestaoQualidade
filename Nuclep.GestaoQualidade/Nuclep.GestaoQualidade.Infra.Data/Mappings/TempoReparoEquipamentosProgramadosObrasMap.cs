using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class TempoReparoEquipamentosProgramadosObrasMap:ClassMap<TempoReparoEquipamentosProgramadosObras>
    {
        public TempoReparoEquipamentosProgramadosObrasMap()
        {
            Table("TempoReparoEquipamentosProgramadosObras");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Mes);
            Map(a => a.TotalHoraManutencaoEquipamentoRealizadas);
            Map(a => a.TotalHorasTrabalhadas);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
