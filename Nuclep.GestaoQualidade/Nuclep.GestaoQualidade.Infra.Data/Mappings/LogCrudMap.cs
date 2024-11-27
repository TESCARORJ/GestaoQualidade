using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class LogCrudMap:ClassMap<LogCrud>
    {
        public LogCrudMap()
        {
            Table("LogCrud");

            Id(x => x.Id);

            Map(x => x.IdReferencia);
            Map(x => x.Descricao);
            Map(x => x.LogTipo).CustomType<int>().Column("Tipo");
            Map(x => x.DataHoraCadastro).Column("DataHoraCadastro");

            References(x => x.Usuario).Column("UsuarioId");
            References(x => x.LogTabela).Column("IdLogTabela");
        }
    }
}
