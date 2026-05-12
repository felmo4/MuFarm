using MuFarm.Application.Interfaces.Common;

namespace MuFarm.Infrastructure.Services
{
    public class SystemClock : IClock
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
