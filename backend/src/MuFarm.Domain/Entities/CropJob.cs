using MuFarm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuFarm.Domain.Entities
{
    public class CropJob
    {
        public Guid Id { get; set; }
        public int CropId { get; set; }
        public DateTime ReadyAt { get; set; }
        public CropJobStatus Status { get; set; }
    }
}
