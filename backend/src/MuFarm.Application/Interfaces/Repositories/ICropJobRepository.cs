using MuFarm.Domain.Entities;

namespace MuFarm.Application.Interfaces.Repositories
{
    public interface ICropJobRepository
    {
        Task<IEnumerable<CropJob>?> GetAllAsync();
        Task<IEnumerable<CropJob>?> GetReadyToUpdateJobsAsync();
        Task AddAsync(CropJob newCropJob);
    }
}
