using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class AderenciaProgramacaoMensalMap:ClassMap<AderenciaProgramacaoMensal>
    {
        public AderenciaProgramacaoMensalMap()
        {
            Table("AderenciaProgramacaoMensal");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Mes);
            Map(a => a.TotalAtividadesProgramadas);
            Map(a => a.AtividadesRealizadas);
            Map(a => a.AtividadesCanceladas);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
