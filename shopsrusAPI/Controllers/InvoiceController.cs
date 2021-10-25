using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopsrusAPI.Data;
using shopsrusAPI.Models;
using shopsrusAPI.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shopsrusAPI.Controllers
{
    [Route("api/[controller]")]
    public class InvoiceController : Controller
    {
        private readonly AppDbContext _context;

        public InvoiceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Invoice> invoices = _context.Invoices.Include(i => i.Customer).ToList();
            return Ok(invoices);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Invoice invoice = _context.Invoices.Include(i => i.Customer).Where(i => i.Id == id).FirstOrDefault();
            return Ok(invoice);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CreateInvoiceDTO createInvoiceDTO)
        {
            // find the customer
            Customer customer = _context.Customers.Find(createInvoiceDTO.customerId);
            // find the discount code
            Discount discount = _context.Discounts.Where(d => d.Type == createInvoiceDTO.discountCode).FirstOrDefault();

            // calculate the invoice using the value of the discount code applied

            var percentageDiscount = discount.Value / 100;

            var totalPrice = createInvoiceDTO.Amount * (1 - percentageDiscount);

            // find the discount based on the code applied


            var invoiceItemss = new InvoiceDTO
            {
                Bill = totalPrice,
                customer = customer,
                discountApplied = discount
            };
            var invoiceItem = new Invoice
            {
               Bill = totalPrice,
               Customer = customer,
               Discount = discount.Value
            };

            _context.Invoices.Add(invoiceItem);
            _context.SaveChanges();

            return CreatedAtRoute("Get", new { Id = invoiceItem.Id }, invoiceItem);

            //return Ok(invoiceItem);

            //return Ok(discount);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
