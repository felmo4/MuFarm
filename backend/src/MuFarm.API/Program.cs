using Microsoft.EntityFrameworkCore;
using MuFarm.API.Middlewares;
using MuFarm.Application.DependencyInjection;
using MuFarm.Infrastructure.Data;
using MuFarm.Infrastructure.DependencyInjection;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("MuFarm API starting up");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, config) =>
    {
        config.ReadFrom.Configuration(context.Configuration);
    });
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();
    builder.Services.AddControllers();
    builder.Services.AddOpenApi();

    builder.Services.AddScoped<DbSeeder>();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();


    var app = builder.Build();

    await DbInitializer.InitializeAsync(app.Services);
    
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseAuthorization();
    app.MapControllers();

    app.UseSerilogRequestLogging();
    app.UseExceptionHandler();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
