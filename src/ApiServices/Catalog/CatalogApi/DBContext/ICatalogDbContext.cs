using CatalogApi.Models;
using MongoDB.Driver;

namespace CatalogApi.DBContext
{
    public interface ICatalogDbContext
    {
        IMongoCollection<Product> Products { get; set; }
    }
}
