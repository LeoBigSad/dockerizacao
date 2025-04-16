using Tarefa5.Domain.Interfaces.Postgres;
using Tarefa5.Domain.Models;

namespace Tarefa5.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<Pessoa> PessoaRepository { get; }
        IRepositoryBase<Endereco> EnderecoRepository { get; }
        Task<bool> CommitAsync();
        Task RollbackAsync();
    }
}
