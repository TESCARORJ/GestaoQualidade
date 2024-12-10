using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.SqlServer.Mappings
{
    public class TaxaConformidadeDocumentosQualidadeMetaMap : IEntityTypeConfiguration<TaxaConformidadeDocumentosQualidadeMeta>
    {
        public void Configure(EntityTypeBuilder<TaxaConformidadeDocumentosQualidadeMeta> builder)
        {
            builder.ToTable("Ind_TaxaConformidadeDocumentosQualidadeMeta");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.IsAtivo)
                .HasColumnType("bit");

            builder.Property(a => a.DataHoraCadastro)
                .HasColumnType("datetime2");

            builder.Property(a => a.Meta)
                .HasColumnType("int");

            builder.Property(e => e.DataHoraCadastro)
              .HasColumnType("datetime2");

            builder.Property(e => e.Ano1).HasColumnName("Ano1").HasColumnType("int");
            builder.Property(e => e.Ano2).HasColumnName("Ano2").HasColumnType("int");

            builder.HasOne(e => e.UsuarioCadastro)
                .WithOne()
                .HasForeignKey<TaxaConformidadeDocumentosQualidadeMeta>(e => e.UsuarioCadastroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
