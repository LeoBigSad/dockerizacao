using Tarefa5.Domain.Models;
using Tarefa5.Domain.Interfaces.Rest;

namespace Tarefa5.Data.Rest.Repository
{
    public class AparelhoRepository : BaseRepository, IAparelhoRepository
    {
        private const string AparelhoBaseUrl = "https://localhost:7162/api/Aparelhos";

        public AparelhoRepository() : base(AparelhoBaseUrl) { }

        public async Task<IEnumerable<Aparelho>> GetAllAparelhoAsync()
        {
            var aparelhos = await GetAsync<List<Aparelho>>("");
            return aparelhos.AsEnumerable();
        }
        public async Task<Aparelho> GetAparelhoByIdAsync(Guid id)
        {
            return await GetAsync<Aparelho>($"/{id}");
        }
        public async Task<Aparelho> CreateAparelhoAsync(Aparelho aparelho)
        {
            return await PostAsync<Aparelho>("", aparelho);
        }
        public async Task<Aparelho> UpdateAparelhoAsync(Aparelho aparelho)
        {
            return await PutAsync<Aparelho>($"/{aparelho.Id}", aparelho);
        }
        public async Task<bool> DeleteAparelhoAsync(Guid id)
        {
            return await DeleteAsync($"/{id}");
        }
    }
}
