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
        Task<Facility> GetFacilityAsync(int id, int airportId);
        Task<IEnumerable<Facility>> GetFacilitiesByAirportIdAsync(int airportId);
        Task<IEnumerable<FacilityDto>> GetFacilitiesByAirportIdWithFacTypeAsync(int airportId);
        Task AddFacilityAsync(Facility facility);
        Task UpdateFacilityAsync(Facility facility);
        Task DeleteFacilityAsync(int id);
    }
}