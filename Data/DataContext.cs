using Microsoft.EntityFrameworkCore;

namespace Caifan.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
    }

}

