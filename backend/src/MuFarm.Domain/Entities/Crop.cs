using System;
using System.Collections.Generic;
using System.Text;

namespace MuFarm.Domain.Entities
{
    public class Crop
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public TimeSpan GrowthPeriod { get; set; }
        public decimal PricePerKg { get; set; }

    }
}
