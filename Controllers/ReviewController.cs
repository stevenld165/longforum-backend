using longforum_backend.Data;
using longforum_backend.Models;
using longforum_backend.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace longforum_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(LongforumDbContext context) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Review>> GetReviewById(int id)
        {
            var review = await context.Reviews.FindAsync(id);

            return review == null ? NotFound() : review;
        }

        [HttpGet("User/{username}")]
        public async Task<ActionResult<ICollection<ReviewDto>>> GetReviewsByUsername(string username)
        {
            var reviews = await context.Reviews.Include(r => r.Video)
                .ThenInclude(v => v.Creator)
                .Where(r => r.User.Username == username)
                .OrderByDescending(r => r.CreatedOn)
                .Select(r => new ReviewDto(r)).ToListAsync();

            return reviews;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Review>>> GetReviews()
        {
            return Ok(await context.Reviews.ToListAsync());
        }
        
        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview(Review review)
        {
            context.Reviews.Add(review);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, review);
        }
    }
}
