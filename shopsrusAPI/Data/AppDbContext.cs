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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1,
                FirstName = "Isaac",
                LastName = "Oduh",
                Email = "isoduh@gmail.com",
                Phone = "08031323231"
            }, new Customer {
               Id = 2,
               FirstName = "Moyin",
               LastName = "Lawal",
               Email = "moyinlawal@gmail.com",
               Phone = "08912324323"
            }) ;
        }
    }
}
