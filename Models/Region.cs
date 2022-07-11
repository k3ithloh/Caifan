using System.ComponentModel.DataAnnotations;

namespace Caifan.Models;

public class Region
{
    public Region()
    {
    }

    public Region(int regionId, string regionName)
    {
        RegionId = regionId;
        RegionName = regionName;
    }
    
    [Key]
    public int RegionId { get; set; }
    
    public string RegionName { get; set; } = string.Empty;
    
    public ICollection<University>? Universities { get; set; }
}