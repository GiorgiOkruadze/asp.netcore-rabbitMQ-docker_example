using CatalogApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace CatalogApi.DBContext
{
    public class CatalogDbContext : ICatalogDbContext
    {
        public CatalogDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }

        public IMongoCollection<Product> Products { get; set; }
    }
}
