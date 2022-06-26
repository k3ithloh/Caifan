using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caifan.Models;

public class User
{
    public User()
    {
    }

    public User(int userId, string username, string email, int mobileNo, string passwordEncrypt)
    {
        UserId = userId;
        Username = username;
        Email = email;
        MobileNo = mobileNo;
        PasswordEncrypt = passwordEncrypt;
    }
    
    [Key]
    public int UserId { get; set; }
    
    public string Username { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public int MobileNo { get; set; }
    
    public string PasswordEncrypt { get; set; } = string.Empty;
    
    public ICollection<Review>? Reviews { get; set; }
  
    public ICollection<DegreeUser>? DegreeUsers { get; set; }
}
