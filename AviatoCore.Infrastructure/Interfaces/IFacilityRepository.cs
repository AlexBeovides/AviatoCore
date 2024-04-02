using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Interfaces
{
    public interface IFacilityRepository
    {
        Task<Facility> GetFacilityAsync(int id);
        Task<IEnumerable<Facility>> GetFacilitiesByAirportIdAsync(int airportId);
        Task<IEnumerable<Facility>> GetFacilitiesByAirportIdWithFacTypeAsync();
        Task AddFacilityAsync(Facility facility);
        Task UpdateFacilityAsync(Facility facility);
        Task DeleteFacilityAsync(int id);
    }
}
