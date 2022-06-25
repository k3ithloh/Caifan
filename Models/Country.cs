using System.ComponentModel.DataAnnotations;

namespace Caifan.Models;

public class Country
{
    public Country()
    {
    }

    public Country(string countryId, string countryName)
    {
        CountryId = countryId;
        CountryName = countryName;
    }
    
    [Key]
    public string CountryId { get; set; } = string.Empty;

    public string CountryName { get; set; } = string.Empty;
    
    public ICollection<University>? Universities { get; set; }
}