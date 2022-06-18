using System.ComponentModel.DataAnnotations;

namespace Caifan.Models;

public class Degree
{
    [Key]
    public string DegreeId { get; set; } = string.Empty;
    public string DegreeName { get; set; } = string.Empty;
    public ICollection<University>? Universities { get; set; }
}

