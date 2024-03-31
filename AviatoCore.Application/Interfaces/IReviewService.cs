using AviatoCore.Application.DTOs;
using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Interfaces
{
    public interface IReviewService
    {
        Task<Review> GetReviewAsync(int id, int airportId);
        Task<IEnumerable<ReviewDto>> GetReviewsByAirportIdAsync(int airportId);
        Task AddReviewAsync(Review review);
    }
}
