using System;
using System.Linq;
using System.Threading.Tasks;
using Tarefa5.Data.Postgres.Context;
using Tarefa5.Data.Postgres.Repository;
using Tarefa5.Domain.Interfaces.Postgres;
using Tarefa5.Domain.Interfaces.Repository;
using Tarefa5.Domain.Interfaces.Rest;
using Tarefa5.Domain.Models;

namespace Tarefa5.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostgresDbContext _context;

        private IRepositoryBase<Pessoa> _pessoaRepository;
        private IRepositoryBase<Endereco> _enderecoRepository;

        public UnitOfWork(PostgresDbContext context)
        {
            _context = context;
        }

        public IRepositoryBase<Pessoa> PessoaRepository => _pessoaRepository ?? (_pessoaRepository = new RepositoryBase<Pessoa>(_context));
        public IRepositoryBase<Endereco> EnderecoRepository => _enderecoRepository ?? (_enderecoRepository = new RepositoryBase<Endereco>(_context));

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task RollbackAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                await entry.ReloadAsync();
            }
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
