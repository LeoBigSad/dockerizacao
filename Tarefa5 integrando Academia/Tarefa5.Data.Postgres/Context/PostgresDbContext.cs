using Microsoft.EntityFrameworkCore;
using Tarefa5.Data.Postgres.Configuration;
using Tarefa5.Domain.Models;

namespace Tarefa5.Data.Postgres.Context
{
    public class PostgresDbContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<PessoaEndereco> PessoasEnderecos { get; set; }

        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new PessoaEnderecoConfiguration());
        }
    }
}
