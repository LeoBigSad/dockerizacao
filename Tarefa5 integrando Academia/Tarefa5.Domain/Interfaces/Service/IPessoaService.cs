using Tarefa5.Domain.Models;

namespace Tarefa5.Domain.Interfaces.Service
{
    public interface IPessoaService
    {
        Task<IEnumerable<Pessoa>> BuscarTodosAsync(int page, int perPage);
        Task<Pessoa?> BuscarPorIdAsync(Guid id);
        Task<Pessoa> CriarAsync(Pessoa pessoa);
        Task<Pessoa> AtualizarAsync(Pessoa pessoa);
        Task<bool> DeletarAsync(Guid id);
    }

}
