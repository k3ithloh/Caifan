using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Caifan.Models;

public class Module
{
    public Module()
    {
    }

    public Module(string moduleId, string universityName, string moduleName, string faculty, float credits,string semester = "", string ay = "", string difficulty = "", string popularity = "", string linkToCourseOutline = "", string description = "")
    {
        ModuleId = moduleId; 
        UniversityName = universityName; 
        ModuleName = moduleName; 
        LinkToCourseOutline = linkToCourseOutline; 
        Description = description;
        Faculty = faculty;
        AY = ay;
        Semester = semester;
        Difficulty = difficulty;
        Popularity = popularity;
        Faculty = faculty; 
        Credits = credits; 
    }
    
    // Composite key (ModuleId, UniversityName) is set in DataContext as Composite keys can only be configured using the Fluent API
    public string ModuleId { get; set; }
    
    public string UniversityName { get; set; } = string.Empty;

    public string ModuleName { get; set; } = string.Empty;
    
    public string? LinkToCourseOutline { get; set; } = string.Empty;
    
    public string? Description { get; set; } = string.Empty;
    
    public string Faculty { get; set; } = string.Empty;
    
    public string? AY { get; set; } = string.Empty;
    
    public string? Semester { get; set; } = string.Empty;
    
    //Add this difficulty of modules
    public string? Difficulty { get; set; } = string.Empty;
    //Add popularity of modules
    public string? Popularity { get; set; } = string.Empty;

    
    public float Credits { get; set; }
    
    public virtual University University { get; set; }
    public ICollection<BasketModule>? BasketModules { get; set; }
}
