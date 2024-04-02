using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> GetReviewAsync(int id);
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task AddReviewAsync(Review review);
        Task<IEnumerable<Review>> GetReviewsByServiceIdAsync(int servideId);
        
    }
}
