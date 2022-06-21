using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caifan.Models;

public class User
{
    [Key]
    public int UserId { get; set; }
    
    public string Username { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public int MobileNo { get; set; }
    
    public string PasswordEncrypt { get; set; } = string.Empty;
    
    public ICollection<Review>? Reviews { get; set; }
    
}