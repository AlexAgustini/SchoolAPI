using SchoolAPI.Modules.Core.Filters;

namespace SchoolAPI.Common.Controllers;

public static class ControllerConfigRegistration
{
    public static void RegisterControllersConfig(this IServiceCollection services)
    {
        services.AddControllers(options =>
            {
                options.Filters.Add(new CustomHttpExceptionFilter());

            })
            .AddNewtonsoftJson(options=> options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
    }
}