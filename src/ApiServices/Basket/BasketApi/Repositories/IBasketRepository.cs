using BasketApi.Models;
using System.Threading.Tasks;

namespace BasketApi.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasketsAsync(string userName);
        Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket);
        Task<bool> DeleteBasketAsync(string userName);

    }
}
