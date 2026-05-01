using MuFarm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuFarm.Application.Interfaces.Repositories
{
    public interface ICropRepository
    {
        Task<Crop?> GetByIdAsync(int id);
    }
}
