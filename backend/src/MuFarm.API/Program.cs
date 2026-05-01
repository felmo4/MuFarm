using Microsoft.EntityFrameworkCore;
using MuFarm.Application.Interfaces.Repositories;
using MuFarm.Application.Interfaces.Services;
using MuFarm.Application.Services;
using MuFarm.Infrastructure.Data;
using MuFarm.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<MuFarmDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddScoped<DbSeeder>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICropJobService, CropJobService>();


var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
    var config  = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    var enableSeed = config.GetValue<bool>("Seeding:Enabled");

    if(env.IsDevelopment() && enableSeed)
    {
        var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
        await seeder.SeedAsync();
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
