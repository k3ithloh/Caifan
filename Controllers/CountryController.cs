using Caifan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caifan.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly DataContext _context;
        
        // constructor
        public CountryController(DataContext context)
        {
            _context = context;
        }


        // Get all Countries
        [HttpGet]
        public async Task<ActionResult<List<Country>>> Get()
        {
            return Ok(await _context.Countries.ToListAsync());
        }
        
        // Get a Country based on a given Country ID (cid)
        [HttpGet("{countryid}")]
        public async Task<ActionResult<Country>> Get(string countryid)
        {
            var country = await _context.Countries.FindAsync(countryid);
            if (country == null)
                return BadRequest("Country not found.");
            return Ok(country);
        }
        
        // Add a new Country
        [HttpPost]
        public async Task<ActionResult<List<Country>>> AddCountry([FromBody] Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Countries.ToListAsync());
        }
        
        // Update a Country fields
        [HttpPut]
        public async Task<ActionResult<List<Country>>> UpdateBasket(Country request)
        {
            var dbCountry = await _context.Countries.FindAsync(request.CountryId);
            if (dbCountry == null)
                return BadRequest("Country not found.");
            dbCountry.CountryId = request.CountryId;
            dbCountry.CountryName = request.CountryName;
            
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Countries.ToListAsync());
        }
        
        // Delete a Country based on a given Country ID (bid)
        [HttpDelete("{countryid}")]
        public async Task<ActionResult<List<Country>>> Delete(string countryid)
        {
            var dbCountry = await _context.Countries.FindAsync(countryid);
            if (dbCountry == null)
                return BadRequest("Country not found.");

            _context.Countries.Remove(dbCountry);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Countries.ToListAsync());
        }
    }
    
}