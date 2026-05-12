using MuFarm.Domain.Enums;

namespace MuFarm.Domain.Entities
{
    public class CropJob
    {
        public Guid Id { get; private set; }
        public int CropId { get; private set; }
        public DateTime ReadyAt { get; private set; }
        public CropJobStatus Status { get; private set; }

        private CropJob() { }

        public static CropJob Create(int cropId, TimeSpan growthPeriod, DateTime utcNow)
        {
            return new CropJob
            {
                CropId = cropId,
                ReadyAt = utcNow.Add(growthPeriod),
                Status = CropJobStatus.Growing
            };
        }

    }
}
