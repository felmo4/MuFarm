using MuFarm.Application.DependencyInjection;
using MuFarm.CropGrowthWorker;
using MuFarm.Infrastructure.DependencyInjection;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSerilog(
    (services, lc) => lc.ReadFrom.Configuration(builder.Configuration));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddHostedService<CropGrowthWorker>();

var host = builder.Build();
host.Run();
