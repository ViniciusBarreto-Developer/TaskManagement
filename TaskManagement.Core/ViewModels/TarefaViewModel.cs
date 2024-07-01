using TaskManagement.Core.Enums;

namespace TaskManagement.Core.ViewModels
{
    public class TarefaViewModel
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; }

        public string? Descricao { get; set; }

        public DateTime DataDeCriacao { get; set; }

        public DateTime? DataDeConclusao { get; set; }

        public Status Status { get; set; }
    }
}
