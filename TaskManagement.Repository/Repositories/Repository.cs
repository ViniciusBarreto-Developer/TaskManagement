using MongoDB.Driver;
using TaskManagement.Domain.Contracts.Repositories;
using TaskManagement.Domain.Models;

namespace TaskManagement.Repository.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly IMongoCollection<T> _collection;

        protected Repository(MongoDbContext context, string collectionName)
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

        public virtual async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }

        public virtual async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
