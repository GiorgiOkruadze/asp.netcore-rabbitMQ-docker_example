using DiscountApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountApi.DBContext
{
    public class DiscountDbContext:DbContext
    {
        public DbSet<Coupon> Coupons { get; set; }

        public DiscountDbContext(DbContextOptions<DiscountDbContext> options):base(options) { }

    }
}
