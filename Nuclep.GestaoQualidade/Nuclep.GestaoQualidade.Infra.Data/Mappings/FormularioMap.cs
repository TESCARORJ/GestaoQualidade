using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models.Sistema;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class FormularioMap:ClassMap<Formulario>
    {
        public FormularioMap()
        {
            Table("Formulario");

            Id(x => x.Id);

            Map(x => x.Nome);
            Map(x => x.IsAtivo);
            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");
            Map(x => x.DataHoraCadastro);

        }
    }
}
