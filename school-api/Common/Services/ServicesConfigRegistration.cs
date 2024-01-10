using SchoolAPI.Modules.Courses.Repositories;
using SchoolAPI.Modules.Courses.Services;
using SchoolAPI.Modules.Exams.Repositories;
using SchoolAPI.Modules.Exams.Services;
using SchoolAPI.Modules.Students.Repositories    ;
using SchoolAPI.Modules.Students.Services;
using SchoolAPI.Modules.Teachers.Repositories;
using SchoolAPI.Modules.Teachers.Services;
using SchoolAPI.Modules.Users.Repositories;
using SchoolAPI.Modules.Users.Services;

namespace SchoolAPI.Common.Controllers;

public static class ServicesConfigRegistration
{
    public static void ConfigureDependencies(this IServiceCollection services)
    {
        services.AddScoped<CoursesService>();
        services.AddScoped<CoursesRepository>();
        services.AddScoped<ExamsService>();
        services.AddScoped<ExamsRepository>();
        services.AddScoped<StudentsService>();
        services.AddScoped<StudentsRepository>();
        services.AddScoped<TeachersService>();
        services.AddScoped<TeachersRepository>();
        services.AddScoped<UsersService>();
        services.AddScoped<UsersRepository>();
    }
}