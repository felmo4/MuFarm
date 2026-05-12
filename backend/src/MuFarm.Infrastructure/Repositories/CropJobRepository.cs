using Microsoft.EntityFrameworkCore;
using MuFarm.Application.Interfaces.Repositories;
using MuFarm.Domain.Entities;
using MuFarm.Domain.Enums;
using MuFarm.Infrastructure.Data;


namespace MuFarm.Infrastructure.Repositories
{
    internal class CropJobRepository : ICropJobRepository
    {
        private readonly MuFarmDbContext _context;

        public CropJobRepository(MuFarmDbContext context)
            => this._context = context;

        public async Task<IEnumerable<CropJob>> GetAllAsync()
            => await _context.CropJobs.ToListAsync();

        public async Task AddAsync(CropJob newCropJob)
            => await _context.CropJobs.AddAsync(newCropJob);

        public async Task<int> MarkReadyJobsAsync()
            => await _context.CropJobs
                .Where(x =>
                    x.Status == CropJobStatus.Growing &&
                    x.ReadyAt <= DateTime.UtcNow)
                .ExecuteUpdateAsync(setters =>
                    setters.SetProperty(
                        x => x.Status,
                        CropJobStatus.Ready
                        ));


    }
}
