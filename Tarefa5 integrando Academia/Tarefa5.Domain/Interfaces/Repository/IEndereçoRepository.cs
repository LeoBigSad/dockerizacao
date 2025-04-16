using Tarefa5.Domain.Interfaces.Postgres;
using Tarefa5.Domain.Models;

namespace Tarefa5.Domain.Interfaces.Repository
{

    public interface IEnderecoRepository : IRepositoryBase<Endereco>
    {
        Task<Endereco>? GetByIdAsync(Guid id); 
    }


}
