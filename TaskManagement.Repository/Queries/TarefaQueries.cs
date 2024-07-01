using TaskManagement.Domain.Contracts.Queries;
using TaskManagement.Domain.Models;

namespace TaskManagement.Repository.Queries
{
    public class TarefaQueries : BaseQueries<Tarefa>, ITarefaQueries
    {
        public TarefaQueries(MongoDbContext context) : base(context, "Tarefa")
        {
        }
    }
}
