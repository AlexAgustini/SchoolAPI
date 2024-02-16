using Microsoft.EntityFrameworkCore;

namespace SchoolAPI.Modules.Core.Database;

public static class DatabaseService
{
    public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {   
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }

    public static void MigrateInitialization(this IApplicationBuilder app) {
      using (var serviceScope = app.ApplicationServices.CreateScope()) {
        var serviceDb = serviceScope.ServiceProvider.GetService<DataContext>();

       serviceDb!.Database.Migrate();
      }
    }
}