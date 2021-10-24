using System;
using System.Collections.Generic;
using System.Linq;
using shopsrusAPI.Data;
using shopsrusAPI.Models;

namespace shopsrusAPI.Services
{
    public class DiscountService : IDataRepository<Discount>
    {
        readonly AppDbContext _context;
        public DiscountService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Discount> GetAll()
        {
            return _context.Discounts.ToList();
        }

        public Discount Get(int id)
        {
            return _context.Discounts.FirstOrDefault(d => d.Id == id);
        }

        public void Add(Discount entity)
        {
            _context.Discounts.Add(entity);
            _context.SaveChanges();
        }

        void IDataRepository<Discount>.Update(Discount dbEntity, Discount entity)
        {
            throw new NotImplementedException();
        }

        void IDataRepository<Discount>.Delete(Discount entity)
        {
            throw new NotImplementedException();
        }
    }
}
