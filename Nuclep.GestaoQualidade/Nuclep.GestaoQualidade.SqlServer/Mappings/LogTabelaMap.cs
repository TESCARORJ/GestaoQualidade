using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.SqlServer.Mappings
{
    public class LogTabelaMap : IEntityTypeConfiguration<LogTabela>
    {
        public void Configure(EntityTypeBuilder<LogTabela> builder)
        {
            builder.ToTable("Sys_LogTabela");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome).IsRequired(false);
            builder.Property(a => a.Descricao).IsRequired(false);
        }
    }
}
