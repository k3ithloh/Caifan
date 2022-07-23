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
        string hostUniversityWebsite, float creditTransferRate, string icon = "", int worldRanking = 0, 
        string academicCalendar = "", string academicCalendarLink = "", float gpaRequirement = 0, 
        int noOfPlacesSem1 = 0, int noOfPlacesSem2 = 0, float igpaTenPercentile = 0, 
        float igpaNinetyPercentile = 0, bool accommodation = false, bool insurance = false, 
        bool visa = false, string hostUniversityExchangeWebsite = "", string courseCatalogLink = "", 
        float creditLoadMin = 0, float creditLoadMax = 0, DateTime applicationDeadline = default, string img1 = "", string img2 = ""
        , string img3 = "", string img4 = "", string img5 = "", string img6 = "")
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
        Img1 = img1;
        Img2 = img2;
        Img3 = img3;
        Img4 = img4;
        Img5 = img5;
        Img6 = img6;
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
    
    public float? CreditLoadMin { get; set; }
    
    public float? CreditLoadMax { get; set; }
    
    public float CreditTransferRate { get; set; }

    public DateTime? ApplicationDeadline { get; set; }
    
    public string Latitude { get; set; } = string.Empty;
    
    public string Longitude { get; set; } = string.Empty;
    
    public string? Img1 { get; set; } = string.Empty;
    
    public string? Img2 { get; set; } = string.Empty;
    
    public string? Img3 { get; set; } = string.Empty;

    public string? Img4 { get; set; } = string.Empty;
    
    public string? Img5 { get; set; } = string.Empty;
    
    public string? Img6 { get; set; } = string.Empty;
    
    public ICollection<DegreeUniversity>? DegreeUniversities { get; set; }
    
    public ICollection<Module>? Modules { get; set; }
    
    public ICollection<Review>? Reviews { get; set; }
}




























    
    

























