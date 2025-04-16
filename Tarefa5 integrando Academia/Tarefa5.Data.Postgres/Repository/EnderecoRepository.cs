using Microsoft.EntityFrameworkCore;
using Tarefa5.Data.Postgres.Context;
using Tarefa5.Domain.Interfaces.Repository;
using Tarefa5.Domain.Models;

namespace Tarefa5.Data.Postgres.Repository
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(PostgresDbContext context) : base(context) { }

        public async Task<Endereco?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Endereco>().FindAsync(id);
        }
    }
}

