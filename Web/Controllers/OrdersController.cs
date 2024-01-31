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
    public class OrdersController : Controller
    {
        private readonly SDbContext ordersDbContext;

        public OrdersController(SDbContext ordersDbContext)
        {
            this.ordersDbContext = ordersDbContext;
        }

        //Get All Orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await ordersDbContext.Orders.ToListAsync();
            return Ok(orders);
        }

        // Get single Order
        [HttpGet]
        [Route("{id:long}")]
        [ActionName("GetOrder")]
        public async Task<IActionResult> GetOrder([FromRoute] long id)
        {
            var orders = await ordersDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (orders != null)
            {
                return Ok(orders);
            }
            return NotFound("Order not found"); 
        }

        [HttpPost]
        [Route("AddOrder")]
        [ActionName("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] Orders orders)
        {
            await ordersDbContext.Orders.AddAsync(orders);
            await ordersDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrder), new { id = orders.Id }, orders);
        }

    }
}
