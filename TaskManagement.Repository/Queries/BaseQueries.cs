using MongoDB.Driver;
using TaskManagement.Domain.Contracts.Queries;
using TaskManagement.Domain.Models;

namespace TaskManagement.Repository.Queries
{
    public abstract class BaseQueries<T> : IBaseQueries<T> where T : Entity
    {
        protected readonly IMongoCollection<T> _collection;

        protected BaseQueries(MongoDbContext context, string collectionName)
        {
            _collection = context.Database.GetCollection<T>(collectionName);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
