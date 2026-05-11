
namespace MuFarm.Application.Interfaces.Services
{
    public interface ICropJobService
    {
        Task<Guid> PlantCropAsync(int cropId);
        Task ProcessReadyJobAsync();
        Task HarvestCropAsync(Guid cropJobId);
    }
}
