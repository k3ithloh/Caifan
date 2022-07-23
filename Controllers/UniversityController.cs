using Caifan.Models;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caifan.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private readonly DataContext _context;
        
        public UniversityController(DataContext context)
        {
            _context = context;
        }


        //This is to get all Universities
        [HttpGet]
        public async Task<ActionResult<List<University>>> Get()
        {
            return Ok(await _context.Universities.ToListAsync());
        }
        
        //This is to get a single row out
        [HttpGet("{universityid}")]
        public async Task<ActionResult<University>> Get(string universityid)
        {
            var university = await _context.Universities.FindAsync(universityid);
            if (university == null)
                return BadRequest("University not found.");
            return Ok(university);
        }
        
        //This is to add new rows into the Database
        [HttpPost]
        public async Task<ActionResult<List<University>>> AddMajor([FromBody] University university)
        {
            _context.Universities.Add(university);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Universities.ToListAsync());
        }
        
        //This is to update a row in the Database
        [HttpPut]
        public async Task<ActionResult<List<University>>> UpdateBasket(University request)
        {
            var dbUniversity = await _context.Universities.FindAsync(request.UniversityName);
            if (dbUniversity == null)
                return BadRequest("University not found.");
            dbUniversity.UniversityName = request.UniversityName;
            dbUniversity.Icon = request.Icon;
            dbUniversity.WorldRanking = request.WorldRanking;
            dbUniversity.Description = request.Description;
            dbUniversity.RegionId = request.RegionId;
            dbUniversity.CountryId = request.CountryId;
            dbUniversity.Address = request.Address;
            dbUniversity.AcademicCalendar = request.AcademicCalendar;
            dbUniversity.AcademicCalendarLink = request.AcademicCalendarLink;
            dbUniversity.GpaRequirement = request.GpaRequirement;
            dbUniversity.NoOfPlacesSem1 = request.NoOfPlacesSem1;
            dbUniversity.NoOfPlacesSem2 = request.NoOfPlacesSem2;
            dbUniversity.IgpaTenPercentile = request.IgpaTenPercentile;
            dbUniversity.IgpaNinetyPercentile = request.IgpaNinetyPercentile;
            dbUniversity.Accommodation = request.Accommodation;
            dbUniversity.Insurance = request.Insurance;
            dbUniversity.Visa = request.Visa;
            dbUniversity.HostUniversityWebsite = request.HostUniversityWebsite;
            dbUniversity.HostUniversityExchangeWebsite = request.HostUniversityExchangeWebsite;
            dbUniversity.CourseCatalogLink = request.CourseCatalogLink;
            dbUniversity.CreditLoadMin = request.CreditLoadMin;
            dbUniversity.CreditLoadMax = request.CreditLoadMax;
            dbUniversity.CreditTransferRate = request.CreditTransferRate;
            dbUniversity.ApplicationDeadline = request.ApplicationDeadline;
            dbUniversity.Latitude = request.Latitude;
            dbUniversity.Longitude = request.Longitude;
            dbUniversity.Img1 = request.Img1;
            dbUniversity.Img2 = request.Img2;
            dbUniversity.Img3 = request.Img3;
            dbUniversity.Img4 = request.Img4;
            dbUniversity.Img5 = request.Img5;
            dbUniversity.Img6 = request.Img6;

            await _context.SaveChangesAsync();
            
            return Ok(await _context.Universities.ToListAsync());
        }
        
        //This is to delete a row in the Database
        [HttpDelete("{universityname}")]
        public async Task<ActionResult<List<University>>> Delete(string universityname)
        {
            var dbUniversity = await _context.Universities.FindAsync(universityname);
            if (dbUniversity == null)
                return BadRequest("University not found.");

            _context.Universities.Remove(dbUniversity);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Universities.ToListAsync());
        }
        
        [HttpGet("search/{text}")]
        public async Task<ActionResult<List<University>>> TextSearch(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                return Ok(await _context.Universities.FullTextSearchQuery(text).ToListAsync());
            }
            else
            {
                return Ok(await _context.Universities.ToListAsync());
            }
        }
    }
    
}