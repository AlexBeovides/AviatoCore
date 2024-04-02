using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly AviatoDbContext _context;

        public WorkerRepository(AviatoDbContext context)
        {
            _context = context;
        }

        public async Task<Worker> GetWorkerAsync(string id)
        {
            var worker = await _context.Workers.FirstOrDefaultAsync(p => p.WorkerId == id);

            if (worker == null)
            {
                throw new KeyNotFoundException("Worker not found");
            }
            return worker;
        }

        public async Task<IEnumerable<Worker>> GetAllWorkersAsync()
        {
            return await _context.Set<Worker>().ToListAsync();
        }

        public async Task AddWorkerAsync(Worker worker)
        {
            await _context.Set<Worker>().AddAsync(worker);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWorkerAsync(Worker worker)
        {
            _context.Set<Worker>().Update(worker);
            await _context.SaveChangesAsync();
        }
    }
}