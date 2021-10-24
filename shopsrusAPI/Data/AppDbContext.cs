using System;
using Microsoft.EntityFrameworkCore;
using shopsrusAPI.Models;

namespace shopsrusAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
    }
}
