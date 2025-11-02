using ComplicadaMente.Components.Data;
using ComplicadaMente.Components.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComplicadaMente.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public RegisterController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Cliente newClient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Cliente.Add(newClient);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { message = "Client successfully registered!" });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = $"Error: {ex.Message}" });
                }
            }

            return BadRequest(new { message = "Invalid data provided." });
        }
    }
}