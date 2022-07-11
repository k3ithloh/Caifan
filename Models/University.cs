using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.DateTime;

namespace Caifan.Models;

public class University
{
    public University()
    {
    }

    public University(string universityName, string description, int regionId, string countryId, string address, 
        string hostUniversityWebsite, int creditTransferRate, string icon = "", int worldRanking = 0, 
        string academicCalendar = "", string academicCalendarLink = "", float gpaRequirement = 0, 
        int noOfPlacesSem1 = 0, int noOfPlacesSem2 = 0, float igpaTenPercentile = 0, 
        float igpaNinetyPercentile = 0, bool accommodation = false, bool insurance = false, 
        bool visa = false, string hostUniversityExchangeWebsite = "", string courseCatalogLink = "", 
        int creditLoadMin = 0, int creditLoadMax = 0, DateTime applicationDeadline = default)
    {
        UniversityName = universityName;
        Icon = icon;
        WorldRanking = worldRanking;
        Description = description;
        RegionId = regionId;
        CountryId = countryId;
        Address = address;
        AcademicCalendar = academicCalendar;
        AcademicCalendarLink = academicCalendarLink;
        GpaRequirement = gpaRequirement;
        NoOfPlacesSem1 = noOfPlacesSem1;
        NoOfPlacesSem2 = noOfPlacesSem2;
        IgpaTenPercentile = igpaTenPercentile;
        IgpaNinetyPercentile = igpaNinetyPercentile;
        Accommodation = accommodation;
        Insurance = insurance;
        Visa = visa;
        HostUniversityWebsite = hostUniversityWebsite;
        HostUniversityExchangeWebsite = hostUniversityExchangeWebsite;
        CourseCatalogLink = courseCatalogLink;
        CreditLoadMin = creditLoadMin;
        CreditLoadMax = creditLoadMax;
        CreditTransferRate = creditTransferRate;
        ApplicationDeadline = applicationDeadline;
    }
    
    [Key]
    public string UniversityName { get; set; } = string.Empty;

    public string? Icon { get; set; } = string.Empty;

    public int? WorldRanking { get; set; }

    public string Description { get; set; } = string.Empty;
    
    public int RegionId { get; set; }
    
    public virtual Region? Region { get; set; }
    
    public string CountryId { get; set; } = string.Empty;
    
    public virtual Country? Country { get; set; }
    
    public string Address { get; set; } = string.Empty;
    
    public string? AcademicCalendar { get; set; } = string.Empty;
    
    public string? AcademicCalendarLink { get; set; } = string.Empty;
    
    public float? GpaRequirement { get; set; }
    
    public int? NoOfPlacesSem1 { get; set; }
    
    public int? NoOfPlacesSem2 { get; set; }
    
    public float? IgpaTenPercentile { get; set; }
    
    public float? IgpaNinetyPercentile { get; set; }
    
    public bool? Accommodation { get; set; }
    
    public bool? Insurance { get; set; }
    
    public bool? Visa { get; set; }
    
    public string HostUniversityWebsite { get; set; } = string.Empty;
    
    public string? HostUniversityExchangeWebsite { get; set; } = string.Empty;
    
    public string? CourseCatalogLink { get; set; } = string.Empty;
    
    public int? CreditLoadMin { get; set; }
    
    public int? CreditLoadMax { get; set; }
    
    public int CreditTransferRate { get; set; }
    
    public DateTime? ApplicationDeadline { get; set; }
    
    public ICollection<DegreeUniversity>? DegreeUniversities { get; set; }
    
    public ICollection<Module>? Modules { get; set; }
    
    public ICollection<Review>? Reviews { get; set; }
}




























    
    

























