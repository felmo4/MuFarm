using MuFarm.Domain.Entities;

namespace MuFarm.Application.Interfaces.Repositories
{
    public interface ICropJobRepository
    {
        Task<IEnumerable<CropJob>> GetAllAsync();
        Task<int> MarkReadyJobsAsync();
        Task AddAsync(CropJob newCropJob);
    }
}
