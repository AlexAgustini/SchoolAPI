using Microsoft.EntityFrameworkCore;

namespace SchoolAPI.Modules.Core.Database;

public static class DatabaseService
{
    public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {   
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}