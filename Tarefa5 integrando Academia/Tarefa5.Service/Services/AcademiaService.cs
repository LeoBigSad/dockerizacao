using Tarefa5.Domain.Interfaces.Rest;
using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Domain.Models;

namespace Tarefa5.Application.Services
{
    public class AcademiaService : IAcademiaService
    {
        public readonly IAcademiaRepository _academiaRepository;
        public  AcademiaService(IAcademiaRepository academiaRepository)
        {
            _academiaRepository = academiaRepository;
        }
        public async Task<IEnumerable<Academia>> BuscarTodosAsync()
        {
            return await _academiaRepository.GetAllAcademiasAsync();
        }
        public async Task<Academia> BuscarPorIdAsync(Guid id)
        {
            return await _academiaRepository.GetAcademiaByIdAsync(id);
        }
        public async Task<Academia> CriarAsync(Academia academia)
        {
            return await _academiaRepository.CreateAcademiaAsync(academia);
        }
        public async Task<Academia> AtualizarAsync(Academia academia)
        {
            return await _academiaRepository.UpdateAcademiaAsync(academia);
        }
        public async Task<bool> DeletarAsync(Guid id)
        {
            var result = await _academiaRepository.DeleteAcademiaAsync(id);
            return result;
        }
    }
}
