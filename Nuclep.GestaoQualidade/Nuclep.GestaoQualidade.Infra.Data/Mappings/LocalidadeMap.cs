using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class LocalidadeMap:ClassMap<Localidade>
    {
        public LocalidadeMap()
        {
            Table("Localidade");

            Id(a => a.Id);

            Map(a => a.Nome);
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
