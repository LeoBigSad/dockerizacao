using System.Text.Json.Serialization;
using Tarefa5.Domain.Entity;

namespace Tarefa5.Domain.Models
{
    public class Aparelho 
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get;  set; }
        public DateTime? UpdatedDate { get;  set; }
        public DateTime? RemovedDate { get;  set; }
        public bool Removed { get;  set; }

        public string Name { get; set; }
    }
}
