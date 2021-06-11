using System.Collections.Generic;
using System.Linq;

namespace BasketApi.Models
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public double TotalPrice => Items.Sum(o => o.Quantity * o.Price);

        public ShoppingCart() { }
        public ShoppingCart(string userName) => UserName = userName;


    }
}
