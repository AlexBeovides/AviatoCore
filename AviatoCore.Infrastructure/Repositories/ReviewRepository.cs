using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AviatoDbContext _context;

        public ReviewRepository(AviatoDbContext context)
        {
            _context = context;
        }

        public async Task<Review> GetReviewAsync(int id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(p => p.Id == id);

            if (review == null)
            {
                throw new KeyNotFoundException("Review not found");
            }

            return review;
        }

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await _context.Set<Review>().ToListAsync();
        }
        public async Task<IEnumerable<Review>> GetReviewsByServiceIdAsync (int serviceId)
        {
            return await _context.Reviews.Where(r => r.ServiceId == serviceId).ToListAsync();
        }

        public async Task AddReviewAsync(Review review)
        {
            await _context.Set<Review>().AddAsync(review);
            await _context.SaveChangesAsync();
        }
    }
}