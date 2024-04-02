using AviatoCore.Application.DTOs;
using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure.Interfaces;
using AviatoCore.Infrastructure;
using AviatoCore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IFacilityRepository _facilityRepository;

        public ReviewService(IReviewRepository reviewRepository,
            IServiceRepository serviceRepository,
             IFacilityRepository facilityRepository)
        {
            _reviewRepository = reviewRepository;
            _serviceRepository = serviceRepository;
            _facilityRepository = facilityRepository;
        }

        public async Task<Review> GetReviewAsync(int id, int airportId)
        {
            var review = await _reviewRepository.GetReviewAsync(id);
            var service = await _serviceRepository.GetServiceAsync(review.ServiceId);
            var facility = await _facilityRepository.GetFacilityAsync(service.FacilityId);

            if (facility.AirportId != airportId)
            {
                throw new UnauthorizedAccessException("You do not have access to this service");
            }

            //review.Service = null;     // Fixes: A possible object cycle was detected.
            return review;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByAirportIdAsync(int airportId)
        {
            var facilities = await _facilityRepository.GetFacilitiesByAirportIdAsync(airportId);
            var facilityIds = facilities.Select(f => f.Id).ToList();
            var services = await _serviceRepository.GetAllServicesAsync();
            var filteredServices = services.Where(s => facilityIds.Contains(s.FacilityId));
            var servicesIds = filteredServices.Select(f => f.Id);

            var allReviews = await _reviewRepository.GetAllReviewsAsync();
            var filteredReviews = allReviews.Where(r => servicesIds.Contains(r.ServiceId));

            var reviewDtos = filteredReviews.Select(r => new ReviewDto
            {
                Id = r.Id,
                Rating = r.Rating,
                Comment = r.Comment,
                ReviewedAt = r.ReviewedAt,
                ClientId = r.ClientId,
                ServiceId = r.ServiceId
            });

            return reviewDtos;
        }

        public async Task AddReviewAsync(Review review)
        {
            await _reviewRepository.AddReviewAsync(review);
        }
      
    }
}
