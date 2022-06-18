using Caifan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caifan.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeController : ControllerBase
    {
        private readonly DataContext _context;
        
        public DegreeController(DataContext context)
        {
            _context = context;
        }


        //This is to get all degrees
        [HttpGet]
        public async Task<ActionResult<List<Degree>>> Get()
        {
            return Ok(await _context.Degrees.ToListAsync());
        }
        
        //This is to get a single row out
        [HttpGet("{degreeid}")]
        public async Task<ActionResult<Degree>> Get(string degreeid)
        {
            var degree = await _context.Degrees.FindAsync(degreeid);
            if (degree == null)
                return BadRequest("Major not found.");
            return Ok(degree);
        }
        
        //This is to add new rows into the Database
        [HttpPost]
        public async Task<ActionResult<List<Degree>>> AddMajor([FromBody] Degree degree)
        {
            _context.Degrees.Add(degree);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Degrees.ToListAsync());
        }
        
        //This is to update a row in the Database
        [HttpPut]
        public async Task<ActionResult<List<Degree>>> UpdateBasket(Degree request)
        {
            var dbDegree = await _context.Degrees.FindAsync(request.DegreeId);
            if (dbDegree == null)
                return BadRequest("Degree not found.");
            dbDegree.DegreeId = request.DegreeId;
            dbDegree.DegreeName = request.DegreeName;
            
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Degrees.ToListAsync());
        }
        
        //This is to delete a row in the Database
        [HttpDelete("{degreeid}")]
        public async Task<ActionResult<List<Degree>>> Delete(string degreeid)
        {
            var dbDegree = await _context.Degrees.FindAsync(degreeid);
            if (dbDegree == null)
                return BadRequest("Major not found.");

            _context.Degrees.Remove(dbDegree);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Degrees.ToListAsync());
        }
    }
    
}