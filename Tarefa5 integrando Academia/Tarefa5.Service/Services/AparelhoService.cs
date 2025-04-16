using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Domain.Models;
using Tarefa5.Domain.Interfaces.Rest;

namespace Tarefa5.Application.Services
{
    public class AparelhoService(IAparelhoRepository aparelhoRepository) : IAparelhoService
    {

        public async Task<IEnumerable<Aparelho>> BuscarTodosAsync()
        {
            return await aparelhoRepository.GetAllAparelhoAsync();
        }

        public async Task<Aparelho> BuscarPorIdAsync(Guid id)
        {
            return await aparelhoRepository.GetAparelhoByIdAsync(id);
        }

        public async Task<Aparelho> CriarAsync(Aparelho aparelho)
        {
            return await aparelhoRepository.CreateAparelhoAsync(aparelho);
        }

        public async Task<Aparelho> AtualizarAsync(Aparelho aparelho)
        {
            return await aparelhoRepository.UpdateAparelhoAsync(aparelho);
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var aparelho = await aparelhoRepository.DeleteAparelhoAsync(id);
            return aparelho != null;
        }
    }
}
