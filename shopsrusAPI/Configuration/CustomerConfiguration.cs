using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shopsrusAPI.Models;

namespace shopsrusAPI.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasData(
                new Customer
                {
                    Id = 2,
                    FirstName = "Tom",
                    LastName = "Jones",
                    Email = "tjones@gmail.com",
                    Phone = "09012354675"
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Jane",
                    LastName = "Sloan",
                    Email = "janesloan@gmail.com",
                    Phone = "09081346657"
                }
            );
        }
    }
}
