using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CatalogApi.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; } 
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public double Price { get; set; }
    }
}
