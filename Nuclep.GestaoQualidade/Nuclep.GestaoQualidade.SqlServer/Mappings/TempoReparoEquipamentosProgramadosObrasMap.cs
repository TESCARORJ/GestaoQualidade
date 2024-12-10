using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.SqlServer.Mappings
{
    public class TempoReparoEquipamentosProgramadosObrasMap : IEntityTypeConfiguration<TempoReparoEquipamentosProgramadosObras>
    {
        public void Configure(EntityTypeBuilder<TempoReparoEquipamentosProgramadosObras> builder)
        {
            builder.ToTable("Ind_TempoReparoEquipamentosProgramadosObras");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Ano).HasColumnName("Ano").HasColumnType("int");

            builder.Property(e => e.Mes).HasColumnName("Mes").HasColumnType("int");

            builder.Property(e => e.TotalHoraManutencaoEquipamentoRealizadas)
                .HasColumnType("decimal(18,2)").IsRequired(false);

            builder.Property(e => e.TotalHorasTrabalhadas)
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


