using CatalogApi.DBContext;
using CatalogApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogDbContext _context = default;

        public ProductRepository(ICatalogDbContext content)
        {
            _context = content;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            try
            {
                await _context.Products.InsertOneAsync(product);
                return true;
            }catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProductAsync(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(o => o.Id, id);
            var response = await _context.Products.DeleteOneAsync(filter);
            return response.IsAcknowledged == true && response.DeletedCount >= 0;
        }

        public async Task<Product> GetProductAsync(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(o => o.Id, id);
            return await _context.Products.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(o => o.Category, categoryName);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(o => o.Name, name);
            return await _context.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.Find(o => true).ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var updateResult = await _context
                                        .Products
                                        .ReplaceOneAsync(g => g.Id == product.Id, product);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }
    }
}
