using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController (DataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUsers>>> GetUsers()
        {
            List<AppUsers> users = await context.Users.ToListAsync();
            if(users.Count == 0) return NotFound("No users found");
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUsers>> GetUser(int id)
        {
            Console.WriteLine($"Requested ID: {id}");
            AppUsers? user = await context.Users.FindAsync(id);
            if(user == null) return NotFound("No user found");
            return Ok(user);
        }
    }
}
