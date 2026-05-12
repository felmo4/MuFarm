using MuFarm.Application.Interfaces.Repositories;
using MuFarm.Infrastructure.Data;


namespace MuFarm.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MuFarmDbContext _context;
        private ICropRepository _crops;
        private ICropJobRepository _cropJob;

        public UnitOfWork(MuFarmDbContext context) 
            => this._context = context;
        
        public ICropRepository Crops => _crops ??= new CropRepository(_context);
        public ICropJobRepository CropJobs => _cropJob ??= new CropJobRepository(_context);

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
