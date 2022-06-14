using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caifan;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int MobileNo { get; set; }
    public string PasswordEncrypt { get; set; } = string.Empty;
    
    [ForeignKey("FirstMajor")]
    public string MajorId { get; set; } = string.Empty;
    [ForeignKey("SecondMajor")]
    public string SecondMajorId { get; set; } = string.Empty;
    
    // [Required] - to add when keith push major code
    // public virtual Major FirstMajor { get; set; } = string.Empty;
    // public virtual Major SecondMajor { get; set; } = string.Empty;
    
    public ICollection<Review>? Reviews { get; set; }
}