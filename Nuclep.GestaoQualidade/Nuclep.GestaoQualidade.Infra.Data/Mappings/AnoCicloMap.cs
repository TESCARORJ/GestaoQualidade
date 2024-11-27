using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class AnoCicloMap:ClassMap<AnoCiclo>
    {
        public AnoCicloMap()
        {
            Table("AnoCiclo");

            Id(a => a.Id);

            Map(a => a.AnoValue1);
            Map(a => a.AnoValue2);
            Map(a => a.DataHoraCadastro);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
