using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Repositories
{
    public class PlaneRepository : IPlaneRepository
    {
        private readonly AviatoDbContext _context;

        public PlaneRepository(AviatoDbContext context)
        {
            _context = context;
        }

        public async Task<Plane> GetPlaneAsync(int id)
        {
            var plane = await _context.Planes.FirstOrDefaultAsync(p => p.Id == id);
            
            if (plane == null)
            {
                throw new KeyNotFoundException("Plane not found");
            }

            return plane;
        }

        public async Task<IEnumerable<Plane>> GetAllPlanesAsync()
        {
            return await _context.Set<Plane>().ToListAsync();
        }

        public async Task AddPlaneAsync(Plane plane)
        {
            await _context.Set<Plane>().AddAsync(plane);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlaneAsync(Plane plane)
        {
            _context.Set<Plane>().Update(plane);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlaneAsync(int id)
        {
            var plane = await GetPlaneAsync(id);
            plane.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}