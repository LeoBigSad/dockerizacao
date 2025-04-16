using Tarefa5.Domain.Interfaces.Postgres;
using Tarefa5.Domain.Models;

namespace Tarefa5.Domain.Interfaces.Repository
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        Task<Pessoa> BuscarComEnderecosAsync(Guid id);

    }
}
