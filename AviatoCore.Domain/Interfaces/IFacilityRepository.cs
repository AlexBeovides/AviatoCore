using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Interfaces
{
    public interface IFacilityRepository
    {
        Task<Facility> GetFacilityAsync(int id);
        Task<IEnumerable<Facility>> GetFacilitiesByAirportIdAsync(int airportId);
        Task AddFacilityAsync(Facility facility);
        Task UpdateFacilityAsync(Facility facility);
        Task DeleteFacilityAsync(int id);
    }
}
