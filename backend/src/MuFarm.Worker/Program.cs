using Microsoft.EntityFrameworkCore;
using MuFarm.Application.Interfaces.Repositories;
using MuFarm.Application.Interfaces.Services;
using MuFarm.Application.Services;
using MuFarm.CropGrowthWorker;
using MuFarm.Infrastructure.Data;
using MuFarm.Infrastructure.Repositories;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<MuFarmDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICropJobService, CropJobService>();
builder.Services.AddHostedService<CropGrowthWorker>();

var host = builder.Build();
host.Run();
