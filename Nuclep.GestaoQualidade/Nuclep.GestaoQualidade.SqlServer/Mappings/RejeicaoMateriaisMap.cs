using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.SqlServer.Mappings
{
    public class RejeicaoMateriaisMap : IEntityTypeConfiguration<RejeicaoMateriais>
    {
        public void Configure(EntityTypeBuilder<RejeicaoMateriais> builder)
        {
            builder.ToTable("Ind_RejeicaoMateriais");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Ano).HasColumnName("Ano").HasColumnType("int");

            builder.Property(e => e.Trimestre).HasColumnName("Trimestre").HasColumnType("int");


            builder.Property(e => e.TotalCTIsRejeitados).HasColumnType("decimal(18,2)").IsRequired(false);

            builder.Property(e => e.TotalCTIsFinalizados).HasColumnType("decimal(18,2)").IsRequired(false);


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