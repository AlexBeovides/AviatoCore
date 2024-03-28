using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Interfaces
{
    public interface IPlaneRepository
    {
        Task<Plane> GetPlaneAsync(int id);
        Task<IEnumerable<Plane>> GetAllPlanesAsync();
        Task AddPlaneAsync(Plane plane);
        Task UpdatePlaneAsync(Plane plane);
        Task DeletePlaneAsync(int id);
    }
}
