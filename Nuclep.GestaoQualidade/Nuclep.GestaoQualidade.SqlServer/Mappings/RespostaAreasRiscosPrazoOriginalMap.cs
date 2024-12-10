using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.SqlServer.Mappings
{
    public class RespostaAreasRiscosPrazoOriginalMap : IEntityTypeConfiguration<RespostaAreasRiscosPrazoOriginal>
    {
        public void Configure(EntityTypeBuilder<RespostaAreasRiscosPrazoOriginal> builder)
        {
            builder.ToTable("Ind_RespostaAreasRiscosPrazoOriginal");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Ano).HasColumnName("Ano").HasColumnType("int");

            builder.Property(e => e.Trimestre).HasColumnName("Trimestre").HasColumnType("int");

            builder.Property(e => e.Realizado).HasColumnType("decimal(18,2)").IsRequired(false);

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