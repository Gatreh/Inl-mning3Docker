using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Inlämning3Docker.Models
{
    public class DbItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string? Name { get; set; }
    }
}