using Caifan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caifan.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly DataContext _context;
        
        public RegionController(DataContext context)
        {
            _context = context;
        }


        //This is to get all Regions
        [HttpGet]
        public async Task<ActionResult<List<Region>>> Get()
        {
            return Ok(await _context.Regions.ToListAsync());
        }
        
        //This is to get a single row out
        [HttpGet("{regionid}")]
        public async Task<ActionResult<Region>> Get(string regionid)
        {
            var region = await _context.Regions.FindAsync(regionid);
            if (region == null)
                return BadRequest("Region not found.");
            return Ok(region);
        }
        
        //This is to add new rows into the Database
        [HttpPost]
        public async Task<ActionResult<List<Region>>> AddRegion([FromBody] Region region)
        {
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Regions.ToListAsync());
        }
        
        //This is to update a row in the Database
        [HttpPut]
        public async Task<ActionResult<List<Region>>> UpdateBasket(Region request)
        {
            var dbRegion = await _context.Regions.FindAsync(request.RegionId);
            if (dbRegion == null)
                return BadRequest("Region not found.");
            dbRegion.RegionId = request.RegionId;
            dbRegion.RegionName = request.RegionName;
            
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Regions.ToListAsync());
        }
        
        //This is to delete a row in the Database
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