using school;
using SchoolAPI.Common.Controllers;
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
builder.Services.AddJwtAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();


