namespace Caifan.Resources;

public static class WebHostExtension
{
    public static IWebHost SeedData(this IWebHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<DataContext>();
                var env = services.GetRequiredService<IWebHostEnvironment>();
                var seeder = new DbInitializer(context, env);
                seeder.Seed();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred initializing the DB");
            }
        }

        return host;
    }
    
}