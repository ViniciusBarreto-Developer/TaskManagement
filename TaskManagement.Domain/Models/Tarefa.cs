using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Models
{
    public class Tarefa : Entity
    {
        public string Titulo { get; set; }

        public string? Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public DateTime? DataDeConclusao { get; set; }

        public Status Status { get; set; }
    }
}
