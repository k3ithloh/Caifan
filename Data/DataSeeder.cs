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
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            int basketId = Int32.Parse(item["BasketId"]);
            var s = new BasketModule(basketId, 
                                    item["ModuleId"]);
            _db.BasketModules.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedBaskets()
    {
        string data = GetData("Baskets");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            int basketId = Int32.Parse(item["BasketId"]);
            var s = new Basket(basketId, 
                                item["BasketName"]);
            _db.Baskets.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedCountries()
    {
        string data = GetData("Countries");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
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
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
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
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            int userId = Int32.Parse(item["UserId"]);
            bool primary = Boolean.Parse(item["Primary"]);
            var s = new DegreeUser(userId, 
                                    item["DegreeId"], 
                                    primary);
            _db.DegreeUsers.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedDegrees()
    {
        string data = GetData("Degrees");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
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
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            int credits = Int32.Parse(item["Credits"]);
            var s = new Module(item["ModuleId"],
                item["UniversityName"],
                item["ModuleName"],
                item["Faculty"],
                credits,
                item["Semester"],
                item["AY"],
                item["Difficulty"],
                item["Popularity"],
                item["LinkToCourseOutline"],
                item["Description"]);
            _db.Modules.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedRegions()
    {
        string data = GetData("Regions");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            int regionId = Int32.Parse(item["RegionId"]);
            var s = new Region(regionId, 
                                item["RegionName"]);
            _db.Regions.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedReviews()
    {
        string data = GetData("Reviews");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            int reviewId = Int32.Parse(item["ReviewId"]);
            int rating = Int32.Parse(item["Rating"]);
            int userId = Int32.Parse(item["UserId"]);
            var s = new Review(reviewId,
                                rating,  
                                userId,  
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
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            
            int worldRanking = Int32.Parse(item["WorldRanking"]);
            int regionId = Int32.Parse(item["RegionId"]);
            float creditTransferRate = float.Parse(item["CreditTransferRate"]);
            float gpaRequirement = 0;
            int noOfPlacesSem1 = 0;
            int noOfPlacesSem2 = 0;
            float igpaTenPercentile = 0;
            float igpaNinetyPercentile = 0;
            bool accommodation = false;
            bool insurance = false;
            bool visa = false;
            float creditLoadMin = 0;
            float creditLoadMax = 0;
            DateTime applicationDeadline = DateTime.Now;
            try
            {
                gpaRequirement = float.Parse(item["GpaRequirement"]);
            }
            catch(ArgumentNullException) {}
            
            try
            {
                noOfPlacesSem1 = Int32.Parse(item["NoOfPlacesSem1"]);
            }
            catch(ArgumentNullException){}
            
            try
            {
                noOfPlacesSem2 = Int32.Parse(item["NoOfPlacesSem2"]);
            }
            catch(ArgumentNullException){}
            
            try
            {
                igpaTenPercentile = float.Parse(item["IgpaTenPercentile"]);
            }
            catch(ArgumentNullException){}
            
            try
            {
                igpaNinetyPercentile = float.Parse(item["IgpaNinetyPercentile"]);
            }
            catch(ArgumentNullException){}
            
            try
            {
                accommodation = Boolean.Parse(item["Accommodation"]);
            }
            catch(ArgumentNullException){}
            
            try
            {
                insurance = Boolean.Parse(item["Insurance"]);
            }
            catch(ArgumentNullException){}
            
            try
            {
                visa = Boolean.Parse(item["Visa"]);
            }
            catch(ArgumentNullException){}
            
            try
            {
                creditLoadMin = float.Parse(item["CreditLoadMin"]);
            }
            catch(ArgumentNullException){}
            
            try
            {
                creditLoadMax = float.Parse(item["CreditLoadMax"]);
            }
            catch(ArgumentNullException){}
            
            try
            {
                applicationDeadline = DateTime.Parse(item["ApplicationDeadline"]);
            }
            catch(ArgumentNullException){}
            
            var s = new University(item["UniversityName"],
                                    item["Description"],
                                    regionId,
                                    item["CountryId"], 
                                    item["Address"],
                                    item["HostUniversityWebsite"],
                                    creditTransferRate,
                                    item["Icon"],
                                    worldRanking,
                                    item["AcademicCalendar"],
                                    item["AcademicCalendarLink"], 
                                    gpaRequirement,
                                    noOfPlacesSem1,
                                    noOfPlacesSem2,
                                    igpaTenPercentile,
                                    igpaNinetyPercentile,
                                    accommodation,
                                    insurance,
                                    visa,
                                    item["HostUniversityExchangeWebsite"],
                                    item["CourseCatalogLink"],
                                    creditLoadMin,
                                    creditLoadMax,
                                    applicationDeadline,
                                    item ["img1"],
                                    item ["img2"],
                                    item ["img3"],
                                    item ["img4"],
                                    item ["img5"],
                                    item ["img6"]);
            _db.Universities.Add(s);
        }
        _db.SaveChanges();
    }
    
    public void SeedUsers()
    {
        string data = GetData("Users");
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            int userId = Int32.Parse(item["UserId"]);
            int mobileNo = Int32.Parse(item["MobileNo"]);
            var s = new User(userId, 
                            item["Username"],
                            item["Email"],
                            mobileNo,
                            item["PasswordEncrypt"]);
            _db.Users.Add(s);
        }
        _db.SaveChanges();
    }
}