using System.ComponentModel.DataAnnotations;

namespace Caifan.Models;

public class Region
{
    public Region()
    {
    }

    public Region(string regionId, string regionName)
    {
        RegionId = regionId;
        RegionName = regionName;
    }
    
    [Key]
    public string RegionId { get; set; }
    
    public string RegionName { get; set; } = string.Empty;
    
    public ICollection<University>? Universities { get; set; }
}