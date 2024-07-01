using TaskManagement.Domain.Contracts.Repositories;
using TaskManagement.Domain.Models;

namespace TaskManagement.Repository.Repositories
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(MongoDbContext context) : base(context, "Tarefa")
        {
        }
    }
}
