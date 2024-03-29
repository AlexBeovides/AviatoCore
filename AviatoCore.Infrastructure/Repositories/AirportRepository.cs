using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly AviatoDbContext _context;

        public AirportRepository(AviatoDbContext context)
        {
            _context = context;
        }

        public async Task<Airport> GetAirportAsync(int id)
        {
            var airport = await _context.Airports.FirstOrDefaultAsync(p => p.Id == id);

            if (airport == null)
            {
                throw new KeyNotFoundException("Airport not found");
            }
            return airport;
        }

        public async Task<IEnumerable<Airport>> GetAllAirportsAsync()
        {
            return await _context.Set<Airport>().ToListAsync();
        }

        public async Task AddAirportAsync(Airport airport)
        {
            await _context.Set<Airport>().AddAsync(airport);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAirportAsync(Airport airport)
        {
            _context.Set<Airport>().Update(airport);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAirportAsync(int id)
        {
            var airport = await GetAirportAsync(id);
            airport.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}