using MuFarm.Domain.Entities;

namespace MuFarm.Infrastructure.Data
{
    public class DbSeeder
    {
        private readonly MuFarmDbContext _context;

        public DbSeeder(MuFarmDbContext context)
            => this._context = context;

        public async Task SeedAsync()
        {
            if (_context.Crops.Any())
                return;

            _context.Crops.AddRange(
                new Crop 
                { 
                    Id = 1, 
                    Name = "Carrot", 
                    GrowthPeriod = TimeSpan.FromMinutes(1),
                    PricePerKg = 30
                },
                new Crop
                {
                    Id= 2,
                    Name = "Cabbage",
                    GrowthPeriod= TimeSpan.FromMinutes(2),
                    PricePerKg = 40
                }
            );

            await _context.SaveChangesAsync();
        }
        
    }
}
