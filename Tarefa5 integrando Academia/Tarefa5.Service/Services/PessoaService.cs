using Microsoft.EntityFrameworkCore;
using Tarefa5.Domain.Interfaces.Repository;
using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Domain.Models;
namespace Tarefa5.Service.Services
{
    public class PessoaService(IUnitOfWork unitOfWork) : IPessoaService
    {

        public async Task<IEnumerable<Pessoa>> BuscarTodosAsync(int page, int perPage)
        {
            return await unitOfWork.PessoaRepository.GetFilteredAsync(
                tracking: false,
                include: y => y.Include(inc => inc.PessoasEnderecos),
                predicate: x => true, 
                orderBy: null,
                page: page,
                perPage: perPage
            );
        }

        public async Task<Pessoa?> BuscarPorIdAsync(Guid id)
        {
            return await unitOfWork.PessoaRepository.GetByIdAsync(id);
        }

        public async Task<Pessoa> CriarAsync(Pessoa pessoa)
        {
            foreach (var pessoaEndereco in pessoa.PessoasEnderecos)
            {
                pessoaEndereco.PessoaId = pessoa.Id;
            }

            await unitOfWork.PessoaRepository.InsertAsync(pessoa);
            await unitOfWork.CommitAsync();
            return pessoa;
        }



        public async Task<Pessoa> AtualizarAsync(Pessoa pessoa)
        {
            var entidadePessoa = await unitOfWork.PessoaRepository.GetByIdAsync(pessoa.Id);
            entidadePessoa.Nome = pessoa.Nome;
            entidadePessoa.DataNascimento = pessoa.DataNascimento;
            entidadePessoa.PessoasEnderecos = pessoa.PessoasEnderecos;
            unitOfWork.PessoaRepository.Update(entidadePessoa);
            await unitOfWork.CommitAsync();
            return entidadePessoa;
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var pessoa = await unitOfWork.PessoaRepository.GetByIdAsync(id);
            if (pessoa == null) return false;

            unitOfWork.PessoaRepository.Delete(pessoa);
            await unitOfWork.CommitAsync();
            return true;
        }
    }

}
