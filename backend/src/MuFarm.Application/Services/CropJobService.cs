using MuFarm.Application.Interfaces.Common;
using MuFarm.Application.Interfaces.Repositories;
using MuFarm.Application.Interfaces.Services;
using MuFarm.Domain.Entities;
using MuFarm.Domain.Enums;


namespace MuFarm.Application.Services
{
    public class CropJobService : ICropJobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClock _clock;

        public CropJobService(IUnitOfWork unitOfWork, IClock clock)
        {
            this._unitOfWork = unitOfWork;
            this._clock = clock;
        }


        public async Task<Guid> PlantCropAsync(int cropId)
        {
            var crop = await _unitOfWork.Crops.GetByIdAsync(cropId);
            if (crop == null)
                throw new KeyNotFoundException("Crop not found");

            var cropJob = CropJob.Create(
                crop.Id,
                crop.GrowthPeriod,
                _clock.UtcNow
            );

            await _unitOfWork.CropJobs.AddAsync(cropJob);
            await _unitOfWork.SaveAsync();

            return cropJob.Id;
        }

        public async Task ProcessReadyJobAsync()
        {
            await _unitOfWork.CropJobs.MarkReadyJobsAsync();
        }

        public Task HarvestCropAsync(Guid cropJobId)
        {
            throw new NotImplementedException();
        }

        
    }
}
