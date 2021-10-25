using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            IEnumerable<Invoice> invoices = _context.Invoices.ToList();
            return Ok(invoices);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CreateInvoiceDTO createInvoiceDTO)
        {
            // calculate the invoice
            var percentageDiscount = createInvoiceDTO.Discount / 100;
            var totalPrice = createInvoiceDTO.Amount * (1 - percentageDiscount);

            var invoiceItem = new InvoiceDTO
            {
                Bill = totalPrice
            };

            return Ok(invoiceItem);
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
