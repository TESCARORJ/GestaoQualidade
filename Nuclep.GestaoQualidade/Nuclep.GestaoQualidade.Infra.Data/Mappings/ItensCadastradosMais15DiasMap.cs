using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class ItensCadastradosMais15DiasMap:ClassMap<ItensCadastradosMais15Dias>
    {
        public ItensCadastradosMais15DiasMap()
        {
            Table("ItensCadastradosMais15Dias");

            Id(a => a.Id);
  
            Map(a => a.IsAtivo);
            Map(a => a.DataHoraCadastro);
            Map(a => a.Ano);
            Map(a => a.Mes);
            Map(a => a.Atividade1);
            Map(a => a.Atividade2);
            Map(a => a.Meta);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");

        }
    }
}
