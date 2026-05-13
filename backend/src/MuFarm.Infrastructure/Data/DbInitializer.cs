using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MuFarm.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<MuFarmDbContext>();

                if (!await db.Database.CanConnectAsync())
                    throw new Exception("Database is not reachable. Is Docker running?");

                await db.Database.MigrateAsync();

                var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
                var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                var enableSeed = bool.Parse(config["Seeding:Enabled"] ?? "false");

                if (env.IsDevelopment() && enableSeed)
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
                    await seeder.SeedAsync();
                }
            }
        }
    }
}
