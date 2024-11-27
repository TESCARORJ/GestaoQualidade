using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.SqlServer.Mappings
{
    public class AcaoCorrecaoAvaliadaEficazMetaMap : IEntityTypeConfiguration<AcaoCorrecaoAvaliadaEficazMeta>
    {
        public void Configure(EntityTypeBuilder<AcaoCorrecaoAvaliadaEficazMeta> builder)
        {
            builder.ToTable("Ind_AcaoCorrecaoAvaliadaEficazMeta");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.IsAtivo)
                .HasColumnType("bit");

            builder.Property(a => a.DataHoraCadastro)
                .HasColumnType("datetime2");

            builder.Property(a => a.Meta)
                .HasColumnType("int");

            builder.Property(e => e.DataHoraCadastro)
              .HasColumnType("datetime2");

            builder.Property(e => e.Ano).HasColumnName("Ano").HasColumnType("int");

            //builder.Property(e => e.Trimestre).HasColumnName("Mes").HasColumnType("int");

            builder.HasOne(e => e.UsuarioCadastro)
                .WithOne()
                .HasForeignKey<AcaoCorrecaoAvaliadaEficazMeta>(e => e.UsuarioCadastroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
