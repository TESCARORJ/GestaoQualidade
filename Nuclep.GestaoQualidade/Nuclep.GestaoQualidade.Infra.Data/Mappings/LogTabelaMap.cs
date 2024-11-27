using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class LogTabelaMap:ClassMap<LogTabela>
    {
        public LogTabelaMap()
        {
            Table("LogTabela");

            Id(a => a.Id);

            Map(a => a.Nome);
            Map(a => a.Descricao);
        }
    }
}
