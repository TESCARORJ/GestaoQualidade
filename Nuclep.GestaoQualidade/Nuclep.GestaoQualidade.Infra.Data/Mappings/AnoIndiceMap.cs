using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class AnoIndiceMap:ClassMap<AnoIndice>
    {
        public AnoIndiceMap()
        {
            Table("AnoIndice");

            Id(a => a.Id);

            Map(a => a.AnoValue);
            Map(a => a.DataHoraCadastro);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
