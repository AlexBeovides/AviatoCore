using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review> GetReviewAsync(int id);
        Task<IEnumerable<Review>> GetAllReviewsAsync();
        Task AddReviewAsync(Review review);
    }
}
