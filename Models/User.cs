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
    
    [ForeignKey("FirstDegree")]
    public string DegreeId { get; set; } = string.Empty;
    [ForeignKey("SecondDegree")]
    public string SecondDegreeId { get; set; } = string.Empty;
    
    // [Required] - to add when keith push major code
    public virtual Degree FirstDegree { get; set; }
    public virtual Degree SecondDegree { get; set; }
    
    public ICollection<Review>? Reviews { get; set; }
}