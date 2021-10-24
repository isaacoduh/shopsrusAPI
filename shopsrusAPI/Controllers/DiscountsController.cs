using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shopsrusAPI.Data;
using shopsrusAPI.Models;
using shopsrusAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace shopsrusAPI.Controllers
{
    [Route("api/[controller]")]
    public class DiscountsController : Controller
    {
        private readonly IDataRepository<Discount> _dataRepository;
        private readonly AppDbContext _context;

        public DiscountsController(IDataRepository<Discount> dataRepository, AppDbContext context)
        {
            _dataRepository = dataRepository;
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Discount> discounts = _dataRepository.GetAll();
            return Ok(discounts);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            Discount discount = _dataRepository.Get(id);
            if(discount == null)
            {
                return NotFound("Discount not found!");
            }

            return Ok(discount);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Discount discount)
        {
            if(discount == null)
            {
                return BadRequest("Discount is null!");
            }
            _dataRepository.Add(discount);
            return CreatedAtRoute("Get", new { Id = discount.Id }, discount);
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
