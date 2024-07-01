using TaskManagement.Domain.Models;

namespace TaskManagement.Domain.Contracts.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(string id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task UpdateAsync(T entity);
    }
}
