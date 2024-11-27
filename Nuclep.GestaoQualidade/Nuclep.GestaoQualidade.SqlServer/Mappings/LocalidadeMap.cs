using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.SqlServer.Mappings
{
    public class LocalidadeMap : IEntityTypeConfiguration<Localidade>
    {
        public void Configure(EntityTypeBuilder<Localidade> builder)
        {
            builder.ToTable("Sys_Localidade");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome).IsRequired();
            builder.Property(a => a.IsAtivo).IsRequired();
            builder.Property(a => a.DataHoraCadastro).IsRequired();

            builder.HasOne(x => x.UsuarioCadastro)
                   .WithMany()
                   .HasForeignKey(x => x.UsuarioCadastroId)
                   .IsRequired();
        }
    }
}
