using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    public interface IFacilityService
    {
        Task<Facility> GetFacilityAsync(int id);
        Task<IEnumerable<Facility>> GetAllFacilitiesAsync();
        Task AddFacilityAsync(Facility facility);
        Task UpdateFacilityAsync(Facility facility);
        Task DeleteFacilityAsync(int id);
    }
}
