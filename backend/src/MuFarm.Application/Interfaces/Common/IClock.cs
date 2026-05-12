using System;
using System.Collections.Generic;
using System.Text;

namespace MuFarm.Application.Interfaces.Common
{
    public interface IClock
    {
        DateTime UtcNow { get; }
    }
}
