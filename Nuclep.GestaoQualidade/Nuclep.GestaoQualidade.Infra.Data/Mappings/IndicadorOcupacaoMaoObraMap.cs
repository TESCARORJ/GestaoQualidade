using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorOcupacaoMaoObraMap:ClassMap<IndicadorOcupacaoMaoObra>
    {
        public IndicadorOcupacaoMaoObraMap()
        {
            Table("IndicadorOcupacaoMaoObra");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Mes);
            Map(a => a.TempoEfetivoFabril);
            Map(a => a.TempoDisponivelFabril);
            Map(a => a.Meta);
            Map(a => a.MetaDesafiadora);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
