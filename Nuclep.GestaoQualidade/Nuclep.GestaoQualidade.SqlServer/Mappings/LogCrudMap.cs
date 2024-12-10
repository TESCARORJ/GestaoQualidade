using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.SqlServer.Mappings
{
    public class LogCrudMap : IEntityTypeConfiguration<LogCrud>
    {
        public void Configure(EntityTypeBuilder<LogCrud> builder)
        {
            builder.ToTable("Sys_LogCrud");

            builder.HasKey(x => x.Id);


            builder.Property(x => x.IdReferencia);
            builder.Property(x => x.LogTipo).HasColumnName("Tipo").HasConversion<int>();
            builder.Property(x => x.LogTabelaId);
            builder.Property(x => x.LogTabelaNome);
            builder.Property(x => x.UsuarioId);
            builder.Property(x => x.UsuarioNome);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.DataHoraCadastro).HasColumnName("DataHoraCadastro");


        }
    }
}
