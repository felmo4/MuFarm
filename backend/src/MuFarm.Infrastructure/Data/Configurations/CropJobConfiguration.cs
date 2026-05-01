

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuFarm.Domain.Entities;

namespace MuFarm.Infrastructure.Data.Configurations
{
    internal class CropJobConfiguration : IEntityTypeConfiguration<CropJob>
    {
        public void Configure(EntityTypeBuilder<CropJob> builder)
        {
            builder.Property(p => p.Status)
                .HasConversion<string>()
                .HasMaxLength(20);
        
        }
    }
}
