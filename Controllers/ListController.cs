using longforum_backend.Data;
using longforum_backend.Enums;
using longforum_backend.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace longforum_backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ListController(LongforumDbContext context) : ControllerBase
{
    [HttpGet("favorites/{username}")]
    public async Task<ActionResult<ListDto>> GetFavoriteListByUsername(string username)
    {
        var favoriteList = await context.Lists.Include(l => l.Entries)
            .ThenInclude(e => e.Review)
            .ThenInclude(r => r.Video)
            .ThenInclude(v => v.Creator)
            .Where(l => l.User.Username == username && l.Type == ListType.Favorite).FirstOrDefaultAsync();
        
        return new ListDto(favoriteList ?? null);
    }
}