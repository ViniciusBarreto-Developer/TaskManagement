using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace TaskManagement.Repository
{
    public class MongoDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = _configuration.GetConnectionString("DbConnection");
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);

            _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoDatabase? Database => _database;
    }
}
