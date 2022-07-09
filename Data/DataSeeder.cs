using System.Reflection;
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

    private string GetData()
    {
        string rootPath = _env.ContentRootPath;
        string filePath = Path.GetFullPath(Path.Combine(rootPath, "Data", "Regions.json"));
        using (var r = new StreamReader(filePath))
        {
            string json = r.ReadToEnd();
            return json;
        }
    }

    public void Seed()
    {
        string data = GetData();
        var items = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        foreach (var item in items)
        {
            var s = new Region(item["RegionId"], item["RegionName"]);
            _db.Regions.Add(s);
        }
        _db.SaveChanges();
    }
}