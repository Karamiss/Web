using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Runtime.InteropServices;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly SDbContext customersDbContext;

        public CustomersController(SDbContext customersDbContext)
        {
            this.customersDbContext = customersDbContext;
        }

        //Get All Customers
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customeres = await customersDbContext.Customers.ToListAsync();
            return Ok(customeres);
        }

        // Get single Customers
        [HttpGet]
        [Route("{id:long}")]
        [ActionName("GetCustomer")]
        public async Task<IActionResult> GetCustomer([FromRoute] long id)
        {
            var customers = await customersDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (customers != null)
            {
                return Ok(customers);
            }
            return NotFound("Customer not found"); 
        }

        //[HttpPost]
        //public async Task<IActionResult> AddCustomer([FromBody] Customers customers)
        //{
        //    await customersDbContext.Customers.AddAsync(customers);
        //    await customersDbContext.SaveChangesAsync();
        //    return CreatedAtAction(nameof(GetCustomer), new { id = customers.Id }, customers);
        //}

    }
}
