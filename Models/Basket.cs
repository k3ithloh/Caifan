using System.ComponentModel.DataAnnotations;

namespace Caifan.Models;

public class Basket
{
    public Basket()
    {
    }

    public Basket(int basketId, string basketName)
    {
        BasketId = basketId;
        BasketName = basketName;
    }
    
    public int BasketId { get; set; }
    
    public string BasketName { get; set; } = string.Empty;
    
    public ICollection<Module>? Modules { get; set; }
}