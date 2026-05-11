using MuFarm.Application.Interfaces.Services;

namespace MuFarm.CropGrowthWorker
{
    public class CropGrowthWorker : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public CropGrowthWorker(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();

                var service = scope.ServiceProvider
                    .GetRequiredService<ICropJobService>();

                await service.ProcessReadyJobAsync();

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
