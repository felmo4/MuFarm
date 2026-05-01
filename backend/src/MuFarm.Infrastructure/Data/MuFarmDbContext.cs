using Microsoft.EntityFrameworkCore;
using MuFarm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuFarm.Infrastructure.Data
{
    public class MuFarmDbContext : DbContext
    {
        public MuFarmDbContext(DbContextOptions<MuFarmDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Crop> Crops => Set<Crop>();
        public DbSet<CropJob> CropJobs => Set<CropJob>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MuFarmDbContext).Assembly);
        }
    }
}
