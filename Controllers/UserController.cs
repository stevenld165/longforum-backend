using longforum_backend.Data;
using longforum_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace longforum_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(LongforumDbContext context) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<User>>> GetUsers()
        {
            return Ok(await context.Users.ToListAsync());
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }
    }
}
