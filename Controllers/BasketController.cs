using Caifan.Models;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caifan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly DataContext _context;

        // constructor
        public BasketController(DataContext context)
        {
            _context = context;
        }
        
        
        // Get all Baskets
        [HttpGet]
        public async Task<ActionResult<List<Basket>>> Get()
        {
            return Ok(await _context.Baskets
                .Include(b=>b.BasketModules)
                .ToListAsync());
        }
        
        
        // Get a Basket based on a given Basket ID (bid)
        [HttpGet("{bid}")]
        public async Task<ActionResult<List<Basket>>> Get(int bid)
        {
            var basket = await _context.Baskets
                .Include(b=>b.BasketModules)
                .FirstOrDefaultAsync(b=>b.BasketId == bid);
            if (basket == null)
                return BadRequest("Basket not found.");
            return Ok(basket);
        }
        
        
        // Add a new Basket
        [HttpPost]
        public async Task<ActionResult<List<Basket>>> AddBasket(Basket basket)
        {
            await _context.Baskets.AddAsync(basket);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Baskets.ToListAsync());
        }
        
        
        // Update a Basket fields
        [HttpPut]
        public async Task<ActionResult<List<Basket>>> UpdateBasket(Basket request)
        {
            var basket = await _context.Baskets.FindAsync(request.BasketId);
            if (basket == null)
                return BadRequest("Basket not found.");
            
            basket.BasketId = request.BasketId;
            basket.BasketName = request.BasketName;
            
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Baskets.ToListAsync());
        }
        
        
        // Delete a Basket based on a given Basket ID (bid)
        [HttpDelete("{bid}")]
        public async Task<ActionResult<List<Basket>>> DeleteBasket(int bid)
        {
            var basket = await _context.Baskets.FindAsync(bid);
            if (basket == null)
                return BadRequest("Basket not found.");

            _context.Baskets.Remove(basket);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Baskets.ToListAsync());
        }
        
        [HttpGet("search/{text}")]
        public async Task<ActionResult<List<Basket>>> TextSearch(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return Ok(await _context.Baskets.FullTextSearchQuery(text).ToListAsync());
            }
            else
            {
                return Ok(await _context.Baskets.ToListAsync());
            }
        }
    }
}