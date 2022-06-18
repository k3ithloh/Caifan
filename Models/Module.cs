using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Caifan.Models;

public class Module
{
    // note that Module has composite key (ModuleId, UniversityName) as two Universities might have the same ModuleId by chance
    // Composite Keys
    public int ModuleId { get; set; }
    public string UniversityName { get; set; } = string.Empty;
    public virtual University University { get; set; }
    
    public string ModuleName { get; set; } = string.Empty;
    public int BasketId { get; set; }
    public string LinkToCourseOutline { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Faculty { get; set; } = string.Empty;
    public int Credits { get; set; }
    
    // not needed bcs its a one to many relationship
    // public ICollection<University>? Universities { get; set; }
    public ICollection<Basket>? Baskets { get; set; }
}

