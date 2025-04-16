using Tarefa5.Domain.Models;

namespace Tarefa5.Domain.Interfaces.Rest
{
    public interface IAparelhoRepository
    {
        Task<IEnumerable<Aparelho>> GetAllAparelhoAsync();
        Task<Aparelho> GetAparelhoByIdAsync(Guid id);
        Task<Aparelho> CreateAparelhoAsync(Aparelho aparelho);
        Task<Aparelho> UpdateAparelhoAsync(Aparelho aparelho);
        Task<bool> DeleteAparelhoAsync(Guid id);
    }
}
