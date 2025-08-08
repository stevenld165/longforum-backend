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
            var user = await context.Users.Include(u => u.Lists).Include(user => user.Reviews).ThenInclude(r => r.Video).ThenInclude(v => v.Creator).FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
                return NotFound();

            var favoriteList = user.Lists.FirstOrDefault(l => l.Type == ListType.Favorite);
            var recentReviews = user.Reviews.OrderByDescending(r => r.CreatedOn).Select(r => new ReviewDto(r)).Take(3).ToList();

            var userDto = new UserDto(user)
            {
                Favorites = new ListDto(favoriteList ?? null),
                RecentReviews = recentReviews
            };
            
            return userDto;
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

            return CreatedAtAction(nameof(GetUserByUsername), new { id = user.Id }, user);
        }
    }
}
