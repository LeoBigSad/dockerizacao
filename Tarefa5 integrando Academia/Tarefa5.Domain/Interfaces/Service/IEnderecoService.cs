using Tarefa5.Domain.Models;

namespace Tarefa5.Domain.Interfaces.Service
{
    public interface IEnderecoService
    {
        Task<IEnumerable<Endereco>> BuscarTodosAsync(int page, int perPage);
        Task<Endereco?> BuscarPorIdAsync(Guid id);
        Task<Endereco> CriarAsync(Endereco endereco);
        Task<Endereco> AtualizarAsync(Endereco endereco);
        Task<bool> DeletarAsync(Guid id);
    }

}
