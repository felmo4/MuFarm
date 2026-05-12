using Microsoft.Extensions.DependencyInjection;
using MuFarm.Application.Interfaces.Services;
using MuFarm.Application.Services;

namespace MuFarm.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {
            services.AddScoped<ICropJobService, CropJobService>();
            
            return services;
        }
    }
}
