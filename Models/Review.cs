using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caifan.Models;

public class Review
{
    [Key]
    public int ReviewId { get; set; }
    
    public int Rating { get; set; }
    
    
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    public string Timestamp { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    

    [ForeignKey("University")]
    public string UniversityName { get; set; } = string.Empty;
    
    
    public virtual University University { get; set; }
    
    public virtual User User { get; set; }
}