using System.ComponentModel.DataAnnotations;

namespace Caifan.Models;

public class Country
{
    [Key]
    public string CountryId { get; set; } = string.Empty;

    public string CountryName { get; set; } = string.Empty;
    
    public ICollection<University>? Universities { get; set; }
}