using EntityFramework.Seeder;
using CsvHelper;
using Caifan.Resources;
using System.Data.Entity.Migrations;

namespace Caifan.Migrations;

internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(DataContext context)
    {
        context.Countries.SeedFromResources("Caifan.Resources.Countries.csv", c => c.Code);
        context.SaveChanges();
    }
}