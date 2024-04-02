using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Repositories
{
    public class RepairRepository : IRepairRepository
    {
        private readonly AviatoDbContext _context;

        public RepairRepository(AviatoDbContext context)
        {
            _context = context;
        }

        public async Task<Repair> GetRepairAsync(int id)
        {
            var repair = await _context.Repairs.FirstOrDefaultAsync(r => r.Id == id);

            if (repair == null)
            {
                throw new KeyNotFoundException("Repair not found");
            }
            return repair;
        }

        public async Task<IEnumerable<Repair>> GetAllRepairsAsync()
        {
            return await _context.Set<Repair>().ToListAsync();
        }

        public async Task AddRepairAsync(Repair repair)
        {
            await _context.Set<Repair>().AddAsync(repair);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRepairAsync(Repair repair)
        {
            _context.Set<Repair>().Update(repair);
            await _context.SaveChangesAsync();
        }
    }
}