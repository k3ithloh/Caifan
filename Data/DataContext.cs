using Caifan.Models;
using Microsoft.EntityFrameworkCore;

namespace Caifan.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    // Creates database tables
    // Degree points to the Degree.cs in models, Degrees refer to the table name in DB
    public DbSet<Degree> Degrees { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Module> Modules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relationships for University
        modelBuilder.Entity<University>()
            .HasOne(u => u.Region)
            .WithMany(r => r.Universities)
            .HasForeignKey(u => u.RegionId);

        modelBuilder.Entity<University>()
            .HasOne(u => u.Country)
            .WithMany(r => r.Universities)
            .HasForeignKey(u => u.CountryId);
        
        modelBuilder.Entity<University>()
            .HasMany(u => u.ApplicableDegree)
            .WithMany(d => d.Universities)
            

        modelBuilder.Entity<University>()
            .ToTable("University")
            .HasRequired(u => u.Country)
            .WithMany(c => c.Universities)
            .HasForeignKey(u => u.CountryId)
            .willCascadeOnDelete(false);
        
        // modelBuilder.Entity<>()
    }


}
