using System;
using System.Collections.Generic;
using System.Linq;
using shopsrusAPI.Data;
using shopsrusAPI.Models;

namespace shopsrusAPI.Services
{
    public class CustomerService : IDataRepository<Customer>
    {
        readonly AppDbContext _context;
        public CustomerService(AppDbContext context)
        {
            _context = context; 
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Customer customer, Customer entity)
        {
            customer.FirstName = entity.FirstName;
            customer.LastName = entity.LastName;
            customer.Email = entity.Email;
            customer.Phone = entity.Phone;
            _context.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        

        

        
    }
}
