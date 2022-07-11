namespace Caifan.Data;

// this is where you will decide the order of the database seeding

public class DbInitializer
{
    private readonly DataContext _db;
    private readonly IWebHostEnvironment _env;

    public DbInitializer(DataContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    public void Seed()
    {
        _db.Database.EnsureCreated();
        
        // seed entities with no foreign keys first
        if (!_db.Baskets.Any())
        {
            var seeder = new DataSeeder(_db, _env);
            seeder.SeedBaskets();
        }
        
        if (!_db.Countries.Any())
        {
            var seeder = new DataSeeder(_db, _env);
            seeder.SeedCountries();
        }
        
        if (!_db.Degrees.Any())
        {
            var seeder = new DataSeeder(_db, _env);
            seeder.SeedDegrees();
        }
        
        if (!_db.Regions.Any())
        {
            var seeder = new DataSeeder(_db, _env);
            seeder.SeedRegions();
        }
        
        if (!_db.Users.Any())
        {
            var seeder = new DataSeeder(_db, _env);
            seeder.SeedUsers();
        }
        
        // then seed the rest in order
        
        if (!_db.Universities.Any() && _db.Countries.Any() && _db.Regions.Any())
        {
            var seeder = new DataSeeder(_db, _env);
            seeder.SeedUniversities();
        }
        
        if (!_db.Modules.Any() && _db.Universities.Any())
        {
            var seeder = new DataSeeder(_db, _env);
            seeder.SeedModules();
        }
        
        if (!_db.BasketModules.Any() && _db.Baskets.Any() && _db.Modules.Any())
        {
            var seeder = new DataSeeder(_db, _env);
            seeder.SeedBasketModule();
        }
        
        if (!_db.DegreeUniversities.Any() && _db.Degrees.Any() && _db.Universities.Any())
        {
            var seeder = new DataSeeder(_db, _env);
            seeder.SeedDegreeUniversity();
        }
        
        if (!_db.DegreeUsers.Any() && _db.Degrees.Any() && _db.Users.Any())
        {
            var seeder = new DataSeeder(_db, _env);
            seeder.SeedDegreeUser();
        }
        
        if (!_db.Reviews.Any() && _db.Universities.Any() && _db.Users.Any())
        {
            var seeder = new DataSeeder(_db, _env);
            seeder.SeedReviews();
        }
    }
}