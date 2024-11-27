using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorEventosAtrasoMap:ClassMap<IndicadorEventosAtraso>
    {
        public IndicadorEventosAtrasoMap()
        {
            Table("IndicadorEventosAtraso");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Mes);
            Map(a => a.NumeroEventosAtraso);
            Map(a => a.NumeroTotalEventos);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
