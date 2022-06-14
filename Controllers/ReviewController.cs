using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caifan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly DataContext _context;

        // constructor
        public ReviewController(DataContext context)
        {
            _context = context;
        }
        
        
        // Get all Reviews
        [HttpGet]
        public async Task<ActionResult<List<Review>>> Get()
        {
            return Ok(await _context.Reviews.ToListAsync());
        }
        
        
        // Get a Review based on a given Review ID (rid)
        [HttpGet("{rid}")]
        public async Task<ActionResult<List<Review>>> Get(int rid)
        {
            var review = await _context.Reviews.FindAsync(rid);
            if (review == null)
                return BadRequest("Review not found.");
            return Ok(review);
        }
        
        
        // Add a new Review
        [HttpPost]
        public async Task<ActionResult<List<Review>>> AddReview(Review review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Reviews.ToListAsync());
        }
        
        
        // Update a Review fields
        [HttpPut]
        public async Task<ActionResult<List<Review>>> UpdateReview(Review request)
        {
            var review = await _context.Reviews.FindAsync(request.ReviewId);
            if (review == null)
                return BadRequest("Review not found.");

            review.ReviewId = request.ReviewId;
            review.Rating = request.Rating;
            review.UserId = request.UserId;
            review.Timestamp = request.Timestamp;
            review.Pros = request.Pros;
            review.Cons = request.Cons;
            review.ReviewTitle = request.ReviewTitle;
            review.UniversityName = request.UniversityName;
            
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Reviews.ToListAsync());
        }
        
        
        // Delete a Review based on a given Review ID (rid)
        [HttpDelete("{rid}")]
        public async Task<ActionResult<List<Review>>> DeleteReview(int rid)
        {
            var review = await _context.Reviews.FindAsync(rid);
            if (review == null)
                return BadRequest("Review not found.");

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Reviews.ToListAsync());
        }
    }
}