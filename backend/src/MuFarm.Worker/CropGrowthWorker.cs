using MuFarm.Application.Interfaces.Services;
using MuFarm.Infrastructure.Data;

namespace MuFarm.CropGrowthWorker
{
    public class CropGrowthWorker : BackgroundService
    {
        private readonly ILogger<CropGrowthWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public CropGrowthWorker(ILogger<CropGrowthWorker> logger, IServiceScopeFactory scopeFactory)
        {
            this._logger = logger;
            this._scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("CropGrowthWorker started");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();

                    var service = scope.ServiceProvider
                        .GetRequiredService<ICropJobService>();

                    await service.ProcessReadyJobAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error occurred while processing ready crop jobs.");
                }

                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
            }
        }
    }
}
