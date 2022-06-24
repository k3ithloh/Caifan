using Caifan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caifan.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreeUserController : ControllerBase
    {
        private readonly DataContext _context;
        
        // constructor
        public DegreeUserController(DataContext context)
        {
            _context = context;
        }


        // Get all DegreeUser
        [HttpGet]
        public async Task<ActionResult<List<DegreeUser>>> Get()
        {
            return Ok(await _context.DegreeUser.ToListAsync());
        }
        
        // Get a DegreeUser based on a given DegreeUser ID (cid)
        [HttpGet("{degreeUserId}")]
        public async Task<ActionResult<DegreeUser>> Get(string degreeUserId)
        {
            var degreeUser= await _context.DegreeUser.FindAsync(degreeUserId);
            if (degreeUser== null)
                return BadRequest("DegreeUser not found.");
            return Ok(degreeUser);
        }
        
        // Add a new DegreeUser
        [HttpPost]
        public async Task<ActionResult<List<DegreeUser>>> AddDegreeUser([FromBody] DegreeUser degreeUser)
        {
            _context.DegreeUser.Add(degreeUser);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.DegreeUser.ToListAsync());
        }
        
        // Update a DegreeUser fields
        [HttpPut]
        public async Task<ActionResult<List<DegreeUser>>> UpdateBasket(DegreeUser request)
        {
            var dbDegreeUser = await _context.DegreeUser.FindAsync(request.UserId, request.DegreeId);
            if (dbDegreeUser == null)
                return BadRequest("DegreeUser not found.");
            dbDegreeUser.UserId = request.UserId;
            dbDegreeUser.DegreeId = request.DegreeId;
            dbDegreeUser.Primary = request.Primary;
            dbDegreeUser.User = request.User;
            dbDegreeUser.Degree = request.Degree;
            
            await _context.SaveChangesAsync();
            
            return Ok(await _context.DegreeUser.ToListAsync());
        }
        
        // Delete a DegreeUser based on a given DegreeUser ID (bid)
        [HttpDelete("{degreeUserId}")]
        public async Task<ActionResult<List<DegreeUser>>> Delete(string degreeUserId)
        {
            var dbDegreeUser = await _context.DegreeUser.FindAsync(degreeUserId);
            if (dbDegreeUser == null)
                return BadRequest("DegreeUser not found.");

            _context.DegreeUser.Remove(dbDegreeUser);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.DegreeUser.ToListAsync());
        }
    }
    
}