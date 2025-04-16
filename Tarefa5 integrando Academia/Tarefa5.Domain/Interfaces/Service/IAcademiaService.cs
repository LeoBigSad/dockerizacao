using Tarefa5.Domain.Models;

namespace Tarefa5.Domain.Interfaces.Service
{
    public interface IAcademiaService
    {
        Task<Academia> AtualizarAsync(Academia academia);
        Task<Academia> BuscarPorIdAsync(Guid id);
        Task<IEnumerable<Academia>> BuscarTodosAsync();
        Task<Academia> CriarAsync(Academia academia);
        Task<bool> DeletarAsync(Guid id);
    }
}
