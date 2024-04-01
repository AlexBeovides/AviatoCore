using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AviatoDbContext _context;

        public FlightRepository(AviatoDbContext context)
        {
            _context = context;
        }

        public async Task<Flight> GetFlightAsync(int id)
        {
            var flight = await _context.Flights.FirstOrDefaultAsync(f => f.Id == id);

            if (flight == null)
            {
                throw new KeyNotFoundException("Flight not found");
            }

            return flight;
        }

        public async Task<IEnumerable<Flight>> GetAllFlightsAsync()
        {
            return await _context.Set<Flight>().ToListAsync();
        }

        public async Task AddFlightAsync(Flight flight)
        {
            await _context.Set<Flight>().AddAsync(flight);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFlightAsync(Flight flight)
        {
            _context.Set<Flight>().Update(flight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlightAsync(int id)
        {
            var flight = await GetFlightAsync(id);
            _context.Set<Flight>().Remove(flight);
            await _context.SaveChangesAsync();
        }
    }
}