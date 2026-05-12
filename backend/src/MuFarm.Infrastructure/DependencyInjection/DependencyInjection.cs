using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MuFarm.Application.Interfaces.Common;
using MuFarm.Application.Interfaces.Repositories;
using MuFarm.Infrastructure.Data;
using MuFarm.Infrastructure.Repositories;
using MuFarm.Infrastructure.Services;

namespace MuFarm.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<MuFarmDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IClock, SystemClock>();

            return services;
        }

    }
}
