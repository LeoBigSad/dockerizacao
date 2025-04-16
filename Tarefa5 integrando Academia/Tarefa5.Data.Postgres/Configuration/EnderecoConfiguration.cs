using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefa5.Domain.Models;

namespace Tarefa5.Data.Postgres.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Rua)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Rua");

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasColumnName("Numero");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Bairro");

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("Cidade");

            builder.Property(e => e.Complemento)
                .HasMaxLength(255)
                .HasColumnName("Complemento");
        }
    }
}
