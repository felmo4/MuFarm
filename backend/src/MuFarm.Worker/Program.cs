using MuFarm.Application.DependencyInjection;
using MuFarm.CropGrowthWorker;
using MuFarm.Infrastructure.DependencyInjection;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddHostedService<CropGrowthWorker>();

var host = builder.Build();
host.Run();
