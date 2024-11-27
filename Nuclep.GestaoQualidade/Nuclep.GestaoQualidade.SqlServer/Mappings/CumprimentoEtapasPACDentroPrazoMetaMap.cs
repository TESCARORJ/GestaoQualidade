using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.SqlServer.Mappings
{
    public class CumprimentoEtapasPACDentroPrazoMetaMap : IEntityTypeConfiguration<CumprimentoEtapasPACDentroPrazoMeta>
    {
        public void Configure(EntityTypeBuilder<CumprimentoEtapasPACDentroPrazoMeta> builder)
        {
            builder.ToTable("Ind_CumprimentoEtapasPACDentroPrazoMeta");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.IsAtivo)
                .HasColumnType("bit");

            builder.Property(a => a.DataHoraCadastro)
                .HasColumnType("datetime2");

            builder.Property(a => a.Meta)
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.DataHoraCadastro)
              .HasColumnType("datetime2");

            builder.Property(e => e.Ano).HasColumnName("Ano").HasColumnType("int");

            //builder.Property(e => e.Mes).HasColumnName("Mes").HasColumnType("int");

            builder.HasOne(e => e.UsuarioCadastro)
                .WithOne()
                .HasForeignKey<CumprimentoEtapasPACDentroPrazoMeta>(e => e.UsuarioCadastroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
