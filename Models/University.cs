using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caifan.Models;

public class University
{
    [Key]
    public string UniversityName { get; set; } = string.Empty;

    public string Icon { get; set; } = string.Empty;

    public int WorldRanking { get; set; }

    public string Description { get; set; } = string.Empty;
    
    // [ForeignKey(("Region"))]
    public int RegionId { get; set; }
    public virtual Region Region { get; set; }
    
    // [ForeignKey(("Country"))]
    public string CountryId { get; set; } = string.Empty;
    public virtual Country Country { get; set; }
    public string Address { get; set; } = string.Empty;
    
    public string AcademicCalendar { get; set; } = string.Empty;
    
    public string AcademicCalendarLink { get; set; } = string.Empty;
    
    public float GpaRequirement { get; set; }
    
    public int NoOfPlacesSem1 { get; set; }
    
    public int NoOfPlacesSem2 { get; set; }
    
    public float IgpaTenPercentile { get; set; }
    
    public float IgpaNinetyPercentile { get; set; }
    
    public bool Accommodation { get; set; }
    
    public bool Insurance { get; set; }
    
    public bool Visa { get; set; }
    
    // [ForeignKey(("ApplicableDegree"))]
    public ICollection<Degree>? Degrees { get; set; }
    
    public string HostUniversityWebsite { get; set; } = string.Empty;
    
    public string HostUniversityExchangeWebsite { get; set; } = string.Empty;

    public string CourseCatalogLink { get; set; } = string.Empty;
    
    public int CreditLoadMin { get; set; }
    
    public int CreditLoadMax { get; set; }
    
    public int CreditTransferRate { get; set; }
    
    public DateTime ApplicationDeadline { get; set; }

    public ICollection<Module>? Modules { get; set; }
    public ICollection<Review>? Reviews { get; set; }
}

