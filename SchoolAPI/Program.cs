using SchoolAPI.Common.Controllers;
using SchoolAPI.Common.Services;
using SchoolAPI.Common.Swagger;
using SchoolAPI.Modules.Auth.Services;
using SchoolAPI.Modules.Core.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterControllersConfig();
builder.Services.RegisterSwaggerConfig();
builder.Services.ConfigureDependencies();
builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration.GetValue<string>("JwtSecret")!);

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Urls.Add("http://*:5000");
app.MigrateInitialization();
app.Run();


