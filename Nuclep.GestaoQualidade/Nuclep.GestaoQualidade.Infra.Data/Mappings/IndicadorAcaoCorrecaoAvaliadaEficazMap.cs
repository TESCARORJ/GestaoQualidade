using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorAcaoCorrecaoAvaliadaEficazMap:ClassMap<IndicadorAcaoCorrecaoAvaliadaEficaz>
    {
        public IndicadorAcaoCorrecaoAvaliadaEficazMap()
        {
            Table("IndicadorAcaoCorrecaoAvaliadaEficaz");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Trimestre);
            Map(a => a.TotalAbertura);
            Map(a => a.TotalFechamento);
            Map(a => a.TotalTratamentoEficaz);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
