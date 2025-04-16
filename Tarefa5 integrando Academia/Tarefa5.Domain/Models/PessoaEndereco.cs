using System.Text.Json.Serialization;

namespace Tarefa5.Domain.Models
{
    public class PessoaEndereco
    {
        public Guid PessoaId { get; set; }

        public Guid EnderecoId { get; set; }
    }
}
