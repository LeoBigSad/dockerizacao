using Tarefa5.Domain.Entity;

namespace Tarefa5.Domain.Models
{
    public class Endereco : Base
    {
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public ICollection<PessoaEndereco> PessoasEnderecos { get; set; } = new List<PessoaEndereco>();
    }

}
