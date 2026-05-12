using Microsoft.EntityFrameworkCore;
using MuFarm.Application.DependencyInjection;
using MuFarm.Application.Interfaces.Common;
using MuFarm.Application.Interfaces.Repositories;
using MuFarm.Application.Interfaces.Services;
using MuFarm.Application.Services;
using MuFarm.CropGrowthWorker;
using MuFarm.Infrastructure.Data;
using MuFarm.Infrastructure.DependencyInjection;
using MuFarm.Infrastructure.Repositories;
using MuFarm.Infrastructure.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddHostedService<CropGrowthWorker>();

var host = builder.Build();
host.Run();
