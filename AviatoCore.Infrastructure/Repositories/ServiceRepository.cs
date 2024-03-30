using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AviatoDbContext _context;

        public ServiceRepository(AviatoDbContext context)
        {
            _context = context;
        }

        public async Task<Service> GetServiceAsync(int id)
        {
            var service = await _context.Services.FirstOrDefaultAsync(p => p.Id == id);

            if (service == null)
            {
                throw new KeyNotFoundException("Service not found");
            }

            return service;
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _context.Set<Service>().ToListAsync();
        }

        public async Task AddServiceAsync(Service service)
        {
            await _context.Set<Service>().AddAsync(service);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateServiceAsync(Service service)
        {
            _context.Set<Service>().Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            var service = await GetServiceAsync(id);
            service.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}