using Microsoft.EntityFrameworkCore;

namespace Caifan.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Basket> Baskets { get; set; }
    }

}

