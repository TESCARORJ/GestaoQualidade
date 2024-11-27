using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorDuracaoProcessoLicitacaoMap:ClassMap<IndicadorDuracaoProcessoLicitacao>
    {
        public IndicadorDuracaoProcessoLicitacaoMap()
        {
            Table("IndicadorDuracaoProcessoLicitacao");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Trimestre);
            Map(a => a.DiasCorridos);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
