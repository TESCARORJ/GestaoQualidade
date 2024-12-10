using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.SqlServer.Mappings
{
    public class TempoReparoEquipamentosProgramadosObrasMetaMap : IEntityTypeConfiguration<TempoReparoEquipamentosProgramadosObrasMeta>
    {
        public void Configure(EntityTypeBuilder<TempoReparoEquipamentosProgramadosObrasMeta> builder)
        {
            builder.ToTable("Ind_TempoReparoEquipamentosProgramadosObrasMeta");

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

            builder.HasOne(e => e.UsuarioCadastro)
                .WithOne()
                .HasForeignKey<TempoReparoEquipamentosProgramadosObrasMeta>(e => e.UsuarioCadastroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


