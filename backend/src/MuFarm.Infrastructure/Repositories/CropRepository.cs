using MuFarm.Application.Interfaces.Repositories;
using MuFarm.Domain.Entities;
using MuFarm.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuFarm.Infrastructure.Repositories
{
    internal class CropRepository : ICropRepository
    {
        private readonly MuFarmDbContext _context;

        public CropRepository(MuFarmDbContext context)
            => this._context = context;

        public async Task<Crop?> GetByIdAsync(int id)
            => await _context.Crops.FindAsync(id);
        
    }
}
