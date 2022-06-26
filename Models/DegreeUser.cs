using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caifan.Models;

// Hard coding this model as we want to add an attribute to indicate if the Degree a User has is their primary
public class DegreeUser
{
    // Composite key is set in DataContext as Composite keys can only be configured using the Fluent API
    // [ForeignKey("User")]
    public int UserId { get; set; }
    
    [ForeignKey("Degree")]
    public string DegreeId { get; set; }
    
    public bool Primary { get; set; }
    
    public User User { get; set; }
    
    public Degree Degree { get; set; }
}