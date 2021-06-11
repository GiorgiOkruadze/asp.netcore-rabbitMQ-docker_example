using BasketApi.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace BasketApi.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        public readonly IDistributedCache _distributedCache = default;

        public BasketRepository(IDistributedCache cache)
        {
            _distributedCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<bool> DeleteBasketAsync(string userName)
        {
            try
            {
                await _distributedCache.RemoveAsync(userName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ShoppingCart> GetBasketsAsync(string userName)
        {
            var basket = await _distributedCache.GetStringAsync(userName);

            return string.IsNullOrEmpty(basket) ? null : JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket)
        {
            await _distributedCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            return await GetBasketsAsync(basket.UserName);
        }
    }
}
