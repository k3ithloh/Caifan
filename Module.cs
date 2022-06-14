namespace Caifan;

public class Module
{
    public int ModuleId { get; set; }
    public string ModuleName { get; set; } = string.Empty;
    public int BasketId { get; set; }
    public string UniversityName { get; set; } = string.Empty;
    public string LinkToCourseOutline { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Faculty { get; set; } = string.Empty;
    public int Credits { get; set; }
    public ICollection<University>? Universities { get; set; }
}

