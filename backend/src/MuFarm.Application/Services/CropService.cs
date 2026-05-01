using MuFarm.Application.Interfaces.Repositories;
using MuFarm.Application.Interfaces.Services;
using MuFarm.Domain.Entities;
using MuFarm.Domain.Enums;


namespace MuFarm.Application.Services
{
    public class CropJobService : ICropJobService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CropJobService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<Guid> PlantCropAsync(int cropId)
        {
            var crop = await _unitOfWork.Crops.GetByIdAsync(cropId);
            if (crop == null)
                throw new KeyNotFoundException("Crop not found");

            var cropJob = new CropJob()
            {
                CropId = crop.Id,
                ReadyAt = DateTime.UtcNow.AddMinutes(crop.GrowthPeriod.TotalMinutes),
                Status = CropJobStatus.Growing
            };

            await _unitOfWork.CropJobs.AddAsync(cropJob);
            await _unitOfWork.SaveAsync();

            return cropJob.Id;
        }

        public Task HarvestCropAsync(Guid cropJobId)
        {
            throw new NotImplementedException();
        }

    }
}
