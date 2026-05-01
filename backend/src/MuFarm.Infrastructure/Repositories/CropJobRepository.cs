using MuFarm.Domain.Entities;
using MuFarm.Infrastructure.Data;
using MuFarm.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;


namespace MuFarm.Infrastructure.Repositories
{
    internal class CropJobRepository : ICropJobRepository
    {
        private readonly MuFarmDbContext _context;

        public CropJobRepository(MuFarmDbContext context)
            => this._context = context;

        public async Task<IEnumerable<CropJob>?> GetAllAsync()
            => await _context.CropJobs.ToListAsync();

        public async Task AddAsync(CropJob newCropJob)
            => await _context.CropJobs.AddAsync(newCropJob);


    }
}
