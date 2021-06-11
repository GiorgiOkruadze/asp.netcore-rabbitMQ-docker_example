using Dapper;
using DiscountApi.DBContext;
using DiscountApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountApi.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        public readonly INpgSqlContext _npgcontext = default;

        public DiscountRepository(INpgSqlContext npgcontext)
        {
            _npgcontext = npgcontext;
        }

        public async Task<bool> CreateDiscountAsync(Coupon coupon)
        {
            using var connection = _npgcontext.GetConnection();
            var affected =
                await connection.ExecuteAsync
                    ("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                            new { coupon.ProductName, coupon.Description, coupon.Amount });

            return affected != 0;

        }

        public async Task<bool> DeleteDiscountAsync(string productName)
        {
            using var connection = _npgcontext.GetConnection();
            var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName",
                new { ProductName = productName });

            return affected != 0;
        }

        public async Task<Coupon> GetDiscountAsync(string productName)
        {
            using var connection = _npgcontext.GetConnection();
            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("Select * From Coupon WHERE ProductName = @ProductName", new { ProductName = productName });
            return coupon;
        }

        public async Task<bool> UpdateDiscountAsync(Coupon coupon)
        {
            using var connection = _npgcontext.GetConnection();
            var affected = await connection.ExecuteAsync
                     ("UPDATE Coupon SET ProductName=@ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
                             new { coupon.ProductName, coupon.Description, coupon.Amount, coupon.Id });


            return affected != 0;
        }
    }
}
