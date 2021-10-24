using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopsrusAPI.Data;
using shopsrusAPI.Models;
using shopsrusAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shopsrusAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IDataRepository<Customer> _dataRepository;
        private readonly AppDbContext _context;

        public CustomersController(IDataRepository<Customer> dataRepository, AppDbContext context)
        {
            _dataRepository = dataRepository;
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Customer> customers = _dataRepository.GetAll();
            return Ok(customers);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Customer customer = _dataRepository.Get(id);
            if(customer == null)
            {
                return NotFound("The customer record cannot be found!");
            }

            return Ok(customer);
        }

        // GET api/customers/{firstname}
        [Route("GetCustomerByName/{name}/")]
        [HttpGet]
        public async Task<IActionResult> GetCustomerByName(string name)
        {
            Customer customer = await _context.Customers
                .Where(c => c.FirstName == name || c.LastName == name)
                .FirstOrDefaultAsync();

            if(customer == null)
            {
                return NotFound("Customer record not found!");
            }
            return Ok(customer);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if(customer == null)
            {
                return BadRequest("Customer is null");
            }

            _dataRepository.Add(customer);
            return CreatedAtRoute("Get", new { Id = customer.Id }, customer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer customer)
        {
            if(customer == null)
            {
                return BadRequest("Customer is null");
            }
            Customer customerToUpdate = _dataRepository.Get(id);
            if(customerToUpdate == null)
            {
                return NotFound("The customer record could not be found");
            }

            _dataRepository.Update(customerToUpdate, customer);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Customer customer = _dataRepository.Get(id);
            if(customer == null)
            {
                return NotFound("The customer record could not be found!");
            }

            _dataRepository.Delete(customer);
            return NoContent();
        }
    }
}
