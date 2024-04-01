using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    public interface IPlaneService
    {
        Task<Plane> GetPlaneAsync(int id);
        Task<IEnumerable<Plane>> GetAllPlanesAsync();
        Task<IEnumerable<Plane>> GetPlanesByOwnerIdAsync(string userId);
        Task AddPlaneAsync(Plane plane);
        Task UpdatePlaneAsync(Plane plane);
        Task DeletePlaneAsync(int id);
    }
}
