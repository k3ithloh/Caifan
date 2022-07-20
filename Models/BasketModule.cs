using System.ComponentModel.DataAnnotations.Schema;

namespace Caifan.Models;

public class BasketModule
{
    public BasketModule()
    {
    }

    public BasketModule(int basketId, string moduleId)
    {
        BasketId = basketId;
        ModuleId = moduleId;
    }
    
    [ForeignKey("Basket")]
    public int BasketId { get; set; }
    
    
    [ForeignKey("Module")]
    public string ModuleId { get; set; }
    
    
    public Basket Basket { get; set; }
    

    public Module Module { get; set; }
}