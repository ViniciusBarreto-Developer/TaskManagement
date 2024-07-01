using TaskManagement.Domain.Models;

namespace TaskManagement.Domain.Contracts.Queries
{
    public interface IBaseQueries<T> where T : Entity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
    }
}
