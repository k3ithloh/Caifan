using Caifan.Models;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caifan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly DataContext _context;

        // constructor
        public ModuleController(DataContext context)
        {
            _context = context;
        }
        
        
        // Get all Modules
        [HttpGet]
        public async Task<ActionResult<List<Module>>> Get()
        {
            return Ok(await _context.Modules
                .Include(m=>m.BasketModules)
                .ToListAsync());
        }
        
        // Get a Module based on a given Module ID (mid)
        [HttpGet("{mid}")]
        public async Task<ActionResult<List<Module>>> Get(string mid)
        {
            var module = await _context.Modules
                .Include(m=>m.BasketModules)
                .FirstOrDefaultAsync(m=>m.ModuleId == mid);
            if (module == null)
                return BadRequest("Module not found.");
            return Ok(module);
        }

        // Add a new Module
        [HttpPost]
        public async Task<ActionResult<List<Module>>> AddModule(Module module)
        {
            await _context.Modules.AddAsync(module);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Modules.ToListAsync());
        }
        
        // Update a Module fields
        [HttpPut]
        public async Task<ActionResult<List<Module>>> UpdateModule(Module request)
        {
            var module = await _context.Modules.FindAsync(request.ModuleId);
            if (module == null)
                return BadRequest("Module not found.");

            module.ModuleId = request.ModuleId;
            module.ModuleName = request.ModuleName;
            module.UniversityName = request.UniversityName;
            module.LinkToCourseOutline = request.LinkToCourseOutline;
            module.Description = request.Description;
            module.Faculty = request.Faculty;
            module.AY = request.AY;
            module.Semester = request.Semester;
            module.Credits = request.Credits;
            module.Difficulty = request.Difficulty;
            module.Popularity = request.Popularity;
            
            
            
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Modules.ToListAsync());
        }

        // Delete a Module based on a given Module ID (mid)
        [HttpDelete("{mid}")]
        public async Task<ActionResult<List<Module>>> DeleteModule(string mid)
        {
            var module = await _context.Modules.FindAsync(mid);
            if (module == null)
                return BadRequest("Module not found.");

            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Modules.ToListAsync());
        }
        
        [HttpGet("search/{text}")]
        public async Task<ActionResult<List<Module>>> TextSearch(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return Ok(await _context.Modules.FullTextSearchQuery(text).ToListAsync());
            }
            else
            {
                return Ok(await _context.Modules.ToListAsync());
            }
        }
    }
}