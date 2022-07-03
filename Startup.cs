using Microsoft.EntityFrameworkCore;

namespace Caifan;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(options => 
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
            );
    }
}

