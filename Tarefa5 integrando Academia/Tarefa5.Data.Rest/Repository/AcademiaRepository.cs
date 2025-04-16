using Tarefa5.Domain.Interfaces.Rest;
using Tarefa5.Domain.Models;

namespace Tarefa5.Data.Rest.Repository
{
    public class AcademiaRepository : BaseRepository, IAcademiaRepository
    {
        private const string AcademiaBaseUrl = "https://localhost:7162/api/Academia";

        public AcademiaRepository() : base(AcademiaBaseUrl) { }

        public async Task<IEnumerable<Academia>> GetAllAcademiasAsync()
        {
            var academias = await GetAsync<List<Academia>>("");
            return academias.AsEnumerable();
        }
        public async Task<Academia> GetAcademiaByIdAsync(Guid id)
        {
            return await GetAsync<Academia>($"/{id}");
        }
        public async Task<Academia> CreateAcademiaAsync(Academia academia)
        {
            return await PostAsync<Academia>("", academia);
        }   
        public async Task<Academia> UpdateAcademiaAsync(Academia academia)
        {
            return await PutAsync<Academia>($"/{academia.Id}", academia);
        }
        public async Task<bool> DeleteAcademiaAsync(Guid id)
        {
            return await DeleteAsync($"/{id}");
        }
    }
}
