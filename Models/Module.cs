using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Caifan.Models;

public class Module
{
    // Composite key (ModuleId, UniversityName) is set in DataContext as Composite keys can only be configured using the Fluent API
    public int ModuleId { get; set; }
    
    public string UniversityName { get; set; } = string.Empty;

    public string ModuleName { get; set; } = string.Empty;
    
    public string? LinkToCourseOutline { get; set; } = string.Empty;
    
    public string? Description { get; set; } = string.Empty;
    
    public string Faculty { get; set; } = string.Empty;
    
    public int Credits { get; set; }
    
    public virtual University University { get; set; }
    public ICollection<Basket>? Baskets { get; set; }
}

