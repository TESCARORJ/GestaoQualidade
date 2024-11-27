using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class DefeitoSoldagemMap:ClassMap<DefeitoSoldagem>
    {
        public DefeitoSoldagemMap()
        {
            Table("DefeitoSoldagem");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Mes);
            Map(a => a.TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos);
            Map(a => a.TotalComprimentoSoldadoInspecionado);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");
            References(x => x.Localidade).Column("IdLocalidade");

        }
    }
}
