using longforum_backend.Data;
using longforum_backend.Enums;
using longforum_backend.Models;
using longforum_backend.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace longforum_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(LongforumDbContext context) : ControllerBase
    {
        [HttpGet("{username}")]
        public async Task<ActionResult<UserDto>> GetUserByUsername(string username)
        {
            var user = await context.Users.Select(u => new UserDto(u))
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return NotFound();
            
            return user;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<UserDto>>> GetUsers()
        {
            return Ok(await context.Users.Select(u => new UserDto(u)).ToListAsync());
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserByUsername), new { id = user.Id }, user);
        }
    }
}
