using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TaskManagement.Domain.Models
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
