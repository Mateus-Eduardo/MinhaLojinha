using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace LojinhaServer.Collections
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [BsonIgnoreIfNull] // Ignora o campo se estiver nulo no documento BSON
        public string Nome { get; set; }

        [BsonElement("description")]
        [BsonIgnoreIfNull]
        public string Description { get; set; }

        [BsonElement("price")]
        [BsonIgnoreIfNull]
        public string Price { get; set; }

        [BsonElement("categorias")]
        [BsonIgnoreIfNull]
        public List<string> Categorias { get; set; }

        [BsonElement("tags")]
        [BsonIgnoreIfNull]
        public string Tags { get; set; }

        [BsonElement("marca")]
        [BsonIgnoreIfNull]
        public string Marca { get; set; }

        
    }
}
