using System.ComponentModel.DataAnnotations;

namespace Caifan.Models;

public class Module
{
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
    
    //This should 
    public virtual University Universities { get; set; }
    public virtual Basket Baskets { get; set; }
}

