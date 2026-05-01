
namespace MuFarm.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ICropRepository Crops { get; }
        ICropJobRepository CropJobs { get; }

        Task<int> SaveAsync();

    }
}
