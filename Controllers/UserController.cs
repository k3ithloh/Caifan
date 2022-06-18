using Caifan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Caifan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        // constructor
        public UserController(DataContext context)
        {
            _context = context;
        }
        
        
        // Get all Users
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _context.Users.ToListAsync());
        }
        
        
        // Get a User based on a given User ID (uid)
        [HttpGet("{uid}")]
        public async Task<ActionResult<List<User>>> Get(int uid)
        {
            var user = await _context.Users.FindAsync(uid);
            if (user == null)
                return BadRequest("User not found.");
            return Ok(user);
        }
        
        
        // Add a new User
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Users.ToListAsync());
        }
        
        
        // Update a User fields
        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return BadRequest("User not found.");

            user.UserId = request.UserId;
            user.Username = request.Username;
            user.Email = request.Email;
            user.MobileNo = request.MobileNo;
            user.PasswordEncrypt = request.PasswordEncrypt;
            user.FirstDegree = request.FirstDegree;
            user.SecondDegree = request.SecondDegree;
            user.Reviews = request.Reviews;

            await _context.SaveChangesAsync();
            
            return Ok(await _context.Users.ToListAsync());
        }
        
        
        // Delete a User based on a given User ID (uid)
        [HttpDelete("{uid}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int uid)
        {
            var user = await _context.Users.FindAsync(uid);
            if (user == null)
                return BadRequest("User not found.");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.Users.ToListAsync());
        }
    }
}