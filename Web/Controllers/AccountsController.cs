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
    public class AccountsController : Controller
    {
        private readonly SDbContext accountsDbContext;

        public AccountsController(SDbContext accountsDbContext)
        {
            this.accountsDbContext = accountsDbContext;
        }

        //Get All Accounts
        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var accounts = await accountsDbContext.Accounts.ToListAsync();
            return Ok(accounts);
        }

        // Get single Account
        [HttpGet]
        [Route("{id:long}")]
        [ActionName("GetAccount")]
        public async Task<IActionResult> GetAccount([FromRoute] long id)
        {
            var accounts = await accountsDbContext.Accounts.FirstOrDefaultAsync(x => x.Id == id);

            if (accounts != null)
            {
                return Ok(accounts);
            }
            return NotFound("Account not found");
        }

        [HttpPost]
        [Route("ValidateAccount")]
        [ActionName("ValidateAccount")]
        public async Task<IActionResult> ValidateAccount([FromBody] Accounts xaccount)
        {

            var accounts = await accountsDbContext.Accounts.FirstOrDefaultAsync(x => x.Username == xaccount.Username);

            if (accounts != null && accounts.Password == xaccount.Password)
            {
                return Ok(accounts);
            }
            return NotFound("Account not found");
        }
    }
}
