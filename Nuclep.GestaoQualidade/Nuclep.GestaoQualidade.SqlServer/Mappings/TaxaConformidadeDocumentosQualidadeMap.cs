using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.SqlServer.Mappings
{
    public class TaxaConformidadeDocumentosQualidadeMap : IEntityTypeConfiguration<TaxaConformidadeDocumentosQualidade>
    {
        public void Configure(EntityTypeBuilder<TaxaConformidadeDocumentosQualidade> builder)
        {
            builder.ToTable("Ind_TaxaConformidadeDocumentosQualidade");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Ano1).HasColumnName("Ano1").HasColumnType("int");
            builder.Property(e => e.Ano2).HasColumnName("Ano2").HasColumnType("int");


            builder.Property(e => e.TotalDocumentos)
                .HasColumnType("decimal(18,2)").IsRequired(false);

            builder.Property(e => e.TotalDentroPrazo)
                .HasColumnType("decimal(18,2)").IsRequired(false);

            builder.Property(e => e.NomeAD)
                .HasColumnType("varchar(255)");

            builder.Property(e => e.IsAtivo)
                .HasColumnType("bit");

            builder.Property(e => e.DataHoraCadastro)
                .HasColumnType("datetime2");

            builder.HasOne(e => e.UsuarioCadastro)
                  .WithMany()
                  .HasForeignKey(e => e.UsuarioCadastroId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


