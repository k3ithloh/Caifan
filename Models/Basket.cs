using System.ComponentModel.DataAnnotations;

namespace Caifan.Models;

public class Basket
{
    [Key]
    public int BasketId { get; set; }
    public string BasketName { get; set; } = string.Empty;
    
    public ICollection<Module>? Modules { get; set; }
}