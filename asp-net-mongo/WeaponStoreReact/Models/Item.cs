using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Runtime.CompilerServices;

//item model, tied to MongoDB
namespace WeaponStoreAPI.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Category { get; set; } = null!;
        public string? Damage { get; set; } = null!;

        public string? Item_id { get; set; } = null!;
    }
}
