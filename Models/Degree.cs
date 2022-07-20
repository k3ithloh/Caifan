using System.ComponentModel.DataAnnotations;

namespace Caifan.Models;

public class Degree
{
    public Degree()
    {
    }

    public Degree(string degreeId, string degreeName)
    {
        DegreeId = degreeId;
        DegreeName = degreeName;
    }
    
    [Key]
    public string DegreeId { get; set; } = string.Empty;
    
    public string DegreeName { get; set; } = string.Empty;
    
    public ICollection<DegreeUniversity>? DegreeUniversities { get; set; }
   
    public ICollection<DegreeUser>? DegreeUsers { get; set; } 
}

