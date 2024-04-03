using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure.Interfaces;
using AviatoCore.Infrastructure.Interfaces.AviatoCore.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Repositories
{
    public class FlightRepairRepository : IFlightRepairRepository
    {
        private readonly AviatoDbContext _context;

        public FlightRepairRepository(AviatoDbContext context)
        {
            _context = context;
        }

        public async Task<FlightRepair> GetFlightRepairAsync(int id)
        {
            var flightRepair = await _context.FlightRepairs.FirstOrDefaultAsync(p => p.Id == id);

            if (flightRepair == null)
            {
                throw new KeyNotFoundException("FlightRepair not found");
            }
            return flightRepair;
        }

        public async Task<IEnumerable<FlightRepair>> GetAllFlightRepairsAsync()
        {
            return await _context.Set<FlightRepair>().ToListAsync();
        }

        public async Task AddFlightRepairAsync(FlightRepair flightRepair)
        {
            await _context.Set<FlightRepair>().AddAsync(flightRepair);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFlightRepairAsync(FlightRepair flightRepair)
        {
            _context.Set<FlightRepair>().Update(flightRepair);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlightRepairAsync(int id)
        {
            var flightRepair = await GetFlightRepairAsync(id);
            _context.Set<FlightRepair>().Remove(flightRepair);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetFlightRepairsByPlaneIdAndServiceIdAsync(int planeId, int serviceId)
        {
            var result = from fr in _context.FlightRepairs
                         join f in _context.Flights on fr.FlightId equals f.Id
                         join r in _context.Repairs on fr.RepairId equals r.Id
                         where f.PlaneId == planeId && r.ServiceId == serviceId
                         select fr;

            return await result.CountAsync();
        }
    }
}