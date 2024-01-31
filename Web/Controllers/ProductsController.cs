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
    public class ProductsController : Controller
    {
        private readonly SDbContext productsDbContext;

        public ProductsController(SDbContext productsDbContext)
        {
            this.productsDbContext = productsDbContext;
        }

        //Get All Products
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await productsDbContext.Products.ToListAsync();
            return Ok(products);
        }

        // Get single Product
        [HttpGet]
        [Route("{id:long}")]
        [ActionName("GetProduct")]
        public async Task<IActionResult> GetProduct([FromRoute] long id)
        {
            var products = await productsDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);

            if (products != null)
            {
                return Ok(products);
            }
            return NotFound("Product not found"); 
        }

        [HttpPost]
        [Route("AddProduct")]
        [ActionName("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Products products)
        {
            await productsDbContext.Products.AddAsync(products);
            await productsDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = products.Id }, products);
        }

    }
}
