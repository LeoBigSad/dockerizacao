using Microsoft.EntityFrameworkCore;
using Tarefa5.Domain.Interfaces.Repository;
using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Domain.Models;

namespace Tarefa5.Service.Services
{
    public class EnderecoService(IUnitOfWork unitOfWork) : IEnderecoService
    {

        public async Task<IEnumerable<Endereco>> BuscarTodosAsync(int page, int perPage)
        {
            return await unitOfWork.EnderecoRepository.GetFilteredAsync(
                tracking: false,
                include: y => y.Include(inc => inc.PessoasEnderecos),
                predicate: x => true,
                orderBy: null,
                page: page,
                perPage: perPage
            );
        }

        public async Task<Endereco?> BuscarPorIdAsync(Guid id)
        {
            return await unitOfWork.EnderecoRepository.GetByIdAsync(id);
        }

        public async Task<Endereco> CriarAsync(Endereco endereco)
        {
            await unitOfWork.EnderecoRepository.InsertAsync(endereco);
            await unitOfWork.CommitAsync();
            return endereco;
        }

        public async Task<Endereco> AtualizarAsync(Endereco endereco)
        {
            unitOfWork.EnderecoRepository.Update(endereco);
            await unitOfWork.CommitAsync();
            return endereco;
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var endereco = await unitOfWork.EnderecoRepository.GetByIdAsync(id);
            if (endereco == null) return false;

            unitOfWork.EnderecoRepository.Delete(endereco);
            await unitOfWork.CommitAsync();
            return true;
        }
    }

}
