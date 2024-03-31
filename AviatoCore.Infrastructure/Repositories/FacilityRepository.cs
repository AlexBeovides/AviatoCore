using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Repositories
{
    public class FacilityRepository : IFacilityRepository
    {
        private readonly AviatoDbContext _context;

        public FacilityRepository(AviatoDbContext context)
        {
            _context = context;
        }

        public async Task<Facility> GetFacilityAsync(int id)
        {
            var facility = await _context.Facilities.FirstOrDefaultAsync(p => p.Id == id);
            
            if (facility == null)
            {
                throw new KeyNotFoundException("Facility not found");
            }

            return facility;
        }

        public async Task<IEnumerable<Facility>> GetFacilitiesByAirportIdAsync(int airportId)
        {
            return await _context.Set<Facility>().Where(f => f.AirportId == airportId).ToListAsync();
        }

        public async Task AddFacilityAsync(Facility facility)
        {
            await _context.Set<Facility>().AddAsync(facility);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFacilityAsync(Facility facility)
        {
            _context.Set<Facility>().Update(facility);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFacilityAsync(int id)
        {
            var facility = await GetFacilityAsync(id);
            facility.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}