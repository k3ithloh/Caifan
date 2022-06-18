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
        
        public CountryController(DataContext context)
        {
            _context = context;
        }


        //This is to get all Countries
        [HttpGet]
        public async Task<ActionResult<List<Country>>> Get()
        {
            return Ok(await _context.Countries.ToListAsync());
        }
        
        //This is to get a single row out
        [HttpGet("{countryid}")]
        public async Task<ActionResult<Country>> Get(string countryid)
        {
            var country = await _context.Countries.FindAsync(countryid);
            if (country == null)
                return BadRequest("Country not found.");
            return Ok(country);
        }
        
        //This is to add new rows into the Database
        [HttpPost]
        public async Task<ActionResult<List<Country>>> AddCountry([FromBody] Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Countries.ToListAsync());
        }
        
        //This is to update a row in the Database
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
        
        //This is to delete a row in the Database
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