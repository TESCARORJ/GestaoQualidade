using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class IndicadorGestaoProcessosPessoasPrevistoPATMap:ClassMap<IndicadorGestaoProcessosPessoasPrevistoPAT>
    {
        public IndicadorGestaoProcessosPessoasPrevistoPATMap()
        {
            Table("IndicadorGestaoProcessosPessoasPrevistoPAT");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Trimestre);
            Map(a => a.Realizado);
            Map(a => a.MetaTrimestre1);
            Map(a => a.MetaTrimestre2);
            Map(a => a.MetaTrimestre3);
            Map(a => a.MetaTrimestre4);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
