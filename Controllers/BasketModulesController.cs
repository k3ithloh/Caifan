using Caifan.Models;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caifan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketModulesController : ControllerBase
    {
        private readonly DataContext _context;

        // constructor
        public BasketModulesController(DataContext context)
        {
            _context = context;
        }
        
        
        // Get all BasketModules
        [HttpGet]
        public async Task<ActionResult<List<BasketModule>>> Get()
        {
            return Ok(await _context.BasketModules
                // .Include(b=>b.BasketModules)
                .ToListAsync());
        }
        
        
        // Get a BasketModules based on a given Basket ID (bid) and Module Id (mid)
        [HttpGet("{bid}/{mid}")]
        public async Task<ActionResult<List<BasketModule>>> Get(int bid, string mid)
        {
            var basketmodule = await _context.BasketModules.FindAsync(bid,mid);
            if (basketmodule == null)
                return BadRequest("BasketModule not found.");
            return Ok(basketmodule);
        }
        
        [HttpGet("search/{text}")]
        public async Task<ActionResult<List<BasketModule>>> TextSearch(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return Ok(await _context.BasketModules.FullTextSearchQuery(text).ToListAsync());
            }
            else
            {
                return Ok(await _context.BasketModules.ToListAsync());
            }
        }
    }
}