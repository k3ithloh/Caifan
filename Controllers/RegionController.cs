using Caifan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caifan.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<RegionController> _logger;
        
        // constructor
        public RegionController(DataContext context, ILogger<RegionController> logger)
        {
            _context = context;
            _logger = logger;
        }


        // Get all Regions
        [HttpGet]
        public async Task<ActionResult<List<Region>>> Get()
        {
            return Ok(await _context.Regions.ToListAsync());
        }
        
        // Get a Region based on a given Region ID (regionid)
        [HttpGet("{regionid}")]
        public async Task<ActionResult<Region>> Get(int regionid)
        {
            var region = await _context.Regions.FindAsync(regionid);
            if (region == null)
                return BadRequest("Region not found.");
            return Ok(region);
        }
        
        // Add a new Region
        [HttpPost("{regionid}/{regionName}")]
        public async Task<ActionResult<List<Region>>> AddRegion([FromBody] Region region)
        {
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Regions.ToListAsync());
        }
        
        // Update a Region fields
        [HttpPut]
        public async Task<ActionResult<List<Region>>> UpdateRegion(Region request)
        {
            var dbRegion = await _context.Regions.FindAsync(request.RegionId);
            if (dbRegion == null)
                return BadRequest("Region not found.");
            dbRegion.RegionId = request.RegionId;
            dbRegion.RegionName = request.RegionName;
            
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Regions.ToListAsync());
        }
        
        // Delete a Region based on a given Region ID (regionid)
        [HttpDelete("{regionid}")]
        public async Task<ActionResult<List<Region>>> Delete(string regionid)
        {
            var dbRegion = await _context.Regions.FindAsync(regionid);
            if (dbRegion == null)
                return BadRequest("Region not found.");

            _context.Regions.Remove(dbRegion);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Regions.ToListAsync());
        }
    }
    
}