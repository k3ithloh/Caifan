using System.Data;
using System.Globalization;
using Caifan.Models;
using Microsoft.EntityFrameworkCore;
using Caifan.Data.Mappings;

namespace Caifan.Data;

public class DataContext : DbContext
{
    public DataContext() { }
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    // Creates database tables
    // Degree points to the Degree.cs in models, Degrees refer to the table name in DB
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<BasketModule> BasketModules { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Degree> Degrees { get; set; }
    public DbSet<DegreeUniversity> DegreeUniversities { get; set; }
    public DbSet<DegreeUser> DegreeUsers { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.UseIdentityColumns();
        
        var basketMap = new BasketMap(builder.Entity<Basket>());
        builder.Entity<Basket>();
        
        var countryMap = new CountryMap(builder.Entity<Country>());
        builder.Entity<Country>();
        
        var degreeMap = new DegreeMap(builder.Entity<Degree>());
        builder.Entity<Degree>();
        
        var degreeUserMap = new DegreeUserMap(builder.Entity<DegreeUser>());
        builder.Entity<DegreeUser>();
        
        var moduleMap = new ModuleMap(builder.Entity<Module>());
        builder.Entity<Module>();
        
        var regionMap = new RegionMap(builder.Entity<Region>());
        builder.Entity<Region>();
        
        var reviewMap = new ReviewMap(builder.Entity<Review>());
        builder.Entity<Review>();
        
        var universityMap = new UniversityMap(builder.Entity<University>());
        builder.Entity<University>();
        
        var userMap = new UserMap(builder.Entity<User>());
        builder.Entity<User>();
        
        var basketModuleMap = new BasketModuleMap(builder.Entity<BasketModule>());
        builder.Entity<BasketModule>();
        
        var degreeUniversityMap = new DegreeUniversityMap(builder.Entity<DegreeUniversity>());
        builder.Entity<DegreeUniversity>();
    }
}

