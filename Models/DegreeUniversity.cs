using System.ComponentModel.DataAnnotations.Schema;

namespace Caifan.Models;

public class DegreeUniversity
{
    public DegreeUniversity()
    {
    }

    public DegreeUniversity(string degreeId, string universityName)
    {
        DegreeId = degreeId;
        UniversityName = universityName;
    }
    
    [ForeignKey("Degree")]
    public string DegreeId { get; set; }
    
    
    [ForeignKey("University")]
    public string UniversityName { get; set; }
    
    
    public Degree Degree { get; set; }
    

    public University University { get; set; }
}