using Tarefa5.Domain.Models;

namespace Tarefa5.Domain.Interfaces.Service
{
    public interface IAparelhoService
    {
        Task<Aparelho> AtualizarAsync(Aparelho aparelho);
        Task<Aparelho> BuscarPorIdAsync(Guid id);
        Task<IEnumerable<Aparelho>> BuscarTodosAsync();
        Task<Aparelho> CriarAsync(Aparelho aparelho);
        Task<bool> DeletarAsync(Guid id);
    }
}
