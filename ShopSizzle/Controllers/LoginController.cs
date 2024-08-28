using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSizzle.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSizzle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly GroceryDbContext _context;

        public LoginController(GroceryDbContext context)
        {
            _context = context;
        }

        [HttpPost("auth-by-id")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDetail login)
        {
            if (login == null || string.IsNullOrWhiteSpace(login.UserId) || string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest(new { message = "UserId and Password are required." });
            }

            // Find the user in the database
            var user = await _context.LoginDetails
                .FirstOrDefaultAsync(u => u.UserId == login.UserId && u.Password == login.Password);

            if (user == null)
            {
                // User not found, return Unauthorized
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // User found, return success response
            return Ok(new { message = "Login successful", user });
        }

         [HttpPost("auth-by-phone")]
        public async Task<IActionResult> AuthenticateByPhone([FromBody] LoginDetail login)
        {
            if (login == null || login.PhoneNo <= 0 )
            {
                return BadRequest(new { message = "Phone number and Password are required." });
            }

            // Find the user in the database
            var user = await _context.LoginDetails
                .FirstOrDefaultAsync(u => u.PhoneNo == login.PhoneNo );

            if (user == null)
            {
                // User not found, return Unauthorized
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // User found, return success response
            return Ok(new { message = "Login successful", user });
        }
   
    }
}
