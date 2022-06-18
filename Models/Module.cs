using System.ComponentModel.DataAnnotations;

namespace Caifan.Models;

public class Module
{
    // note that Module has composite key (ModuleId, UniversityName) as two Universities might have the same ModuleId by chance
    [Key]
    public int ModuleId { get; set; }
    public string ModuleName { get; set; } = string.Empty;
    public int BasketId { get; set; }
    [Key]
    public string UniversityName { get; set; } = string.Empty;
    public string LinkToCourseOutline { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Faculty { get; set; } = string.Empty;
    public int Credits { get; set; }
    public ICollection<University>? Universities { get; set; }
    public ICollection<Basket>? Baskets { get; set; }
}

