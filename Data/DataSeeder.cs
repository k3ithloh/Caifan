using System.Text.Json;
using Caifan.Models;

namespace Caifan.Data;

public class DataSeeder
{
    private readonly DataContext _db;
    private readonly IWebHostEnvironment _env;

    public DataSeeder(DataContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }

    
    // private method for Seeder Methods to get the data according to the specified model
    private string GetData(string modelName)
    {
        string rootPath = _env.ContentRootPath;
        string fileName = modelName + ".json";
        string filePath = Path.GetFullPath(Path.Combine(rootPath, "Data", "JsonFiles", fileName));
        Console.WriteLine(filePath);
        using (var r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            return json;
        }
    }
    
    // Seeder Methods for each model

    public void SeedBasketModule()
    {
        string data = GetData("BasketModules");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(data);
        foreach (var item in items)
        {
            var s = new BasketModule(item["BasketId"], 
                                    item["ModuleId"]);
            _db.BasketModules.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedBaskets()
    {
        string data = GetData("Baskets");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(data);
        foreach (var item in items)
        {
            var s = new Basket(item["BasketId"], 
                                item["BasketName"]);
            _db.Baskets.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedCountries()
    {
        string data = GetData("Countries");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(data);
        foreach (var item in items)
        {
            var s = new Country(item["CountryId"], 
                            item["CountryName"]);
            _db.Countries.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedDegreeUniversity()
    {
        string data = GetData("DegreeUniversities");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(data);
        foreach (var item in items)
        {
            var s = new DegreeUniversity(item["DegreeId"], 
                                    item["UniversityName"]);
            _db.DegreeUniversities.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedDegreeUser()
    {
        string data = GetData("DegreeUsers");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(data);
        foreach (var item in items)
        {
            var s = new DegreeUser(item["UserId"], 
                                    item["DegreeId"], 
                                    item["Primary"]);
            _db.DegreeUsers.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedDegrees()
    {
        string data = GetData("Degrees");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(data);
        foreach (var item in items)
        {
            var s = new Degree(item["DegreeId"],
                            item["DegreeName"]);
            _db.Degrees.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedModules()
    {
        string data = GetData("Modules");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(data);
        foreach (var item in items)
        {
            var s = new Module(item["ModuleId"], 
                item["UniversityName"], 
                item["ModuleName"], 
                item["LinkToCourseOutline"], 
                item["Description"], 
                item["Faculty"], 
                item["Credits"]);
            _db.Modules.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedRegions()
    {
        string data = GetData("Regions");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(data);
        foreach (var item in items)
        {
            var s = new Region(item["RegionId"], 
                                item["RegionName"]);
            _db.Regions.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedReviews()
    {
        string data = GetData("Reviews");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(data);
        foreach (var item in items)
        {
            var s = new Review(item["ReviewId"],
                            item["Rating"],  
                            item["UserId"],  
                            item["Timestamp"],
                            item["Description"],  
                            item["UniversityName"]);
            _db.Reviews.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedUniversities()
    {
        string data = GetData("Universities");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(data);
        foreach (var item in items)
        {
            var s = new University(item["UniversityName"],
                                    item["Icon"],
                                    item["WorldRanking"],
                                    item["Description"],
                                    item["RegionId"],
                                    item["CountryId"], 
                                    item["Address"],
                                    item["AcademicCalendar"],
                                    item["AcademicCalendarLink"], 
                                    item["GpaRequirement"],
                                    item["NoOfPlacesSem1"],
                                    item["NoOfPlacesSem2"],
                                    item["IgpaTenPercentile"],
                                    item["IgpaNinetyPercentile"],
                                    item["Accommodation"],
                                    item["Insurance"],
                                    item["Visa"],
                                    item["HostUniversityWebsite"],
                                    item["HostUniversityExchangeWebsite"],
                                    item["CourseCatalogLink"],
                                    item["CreditLoadMin"],
                                    item["CreditLoadMax"],
                                    item["CreditTransferRate"],
                                    item["ApplicationDeadline"]);
            _db.Universities.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedUsers()
    {
        string data = GetData("Users");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(data);
        foreach (var item in items)
        {
            var s = new User(item["UserId"], 
                            item["Username"],
                            item["Email"],
                            item["MobileNo"],
                            item["PasswordEncrypt"]);
            _db.Users.Add(s);
        }
        _db.SaveChanges();
    }
}