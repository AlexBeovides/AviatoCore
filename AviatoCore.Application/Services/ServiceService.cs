using AviatoCore.Application.DTOs;
using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
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
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IFacilityRepository _facilityRepository;
        private readonly IReviewRepository _reviewRepository; // Assuming you have this

        public ServiceService(IServiceRepository serviceRepository,
             IFacilityRepository facilityRepository, IReviewRepository reviewRepository) // Add it here
        {
            _serviceRepository = serviceRepository;
            _facilityRepository = facilityRepository;
            _reviewRepository = reviewRepository; // And here
        }

        public async Task<Service> GetServiceAsync(int id, int airportId)
        {
            var service = await _serviceRepository.GetServiceAsync(id);
            var facility = await _facilityRepository.GetFacilityAsync(service.FacilityId);

            if(facility.AirportId != airportId)
            {
                throw new UnauthorizedAccessException("You do not have access to this service");
            }

            return service;
        }

        public async Task<IEnumerable<ServiceDto>> GetServicesByAirportIdAsync(int airportId)
        {
            var facilities = await _facilityRepository.GetFacilitiesByAirportIdAsync(airportId);
            var facilityIds = facilities.Select(f => f.Id);

            var allServices = await _serviceRepository.GetAllServicesAsync();
            var filteredServices = allServices.Where(s => facilityIds.Contains(s.FacilityId));

            var serviceDtos = filteredServices.Select(s => new ServiceDto
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                ImgUrl = s.ImgUrl,
                Price = s.Price,
                FacilityId = s.FacilityId,
                IsDeleted = s.IsDeleted
            });

            return serviceDtos;
        }

        public async Task<IEnumerable<ServiceDto>> GetServicesByFacIdAsync(int facilityId)
        {
            var allServices = await _serviceRepository.GetAllServicesAsync();
            var filteredServices = allServices.Where(s =>
                s.FacilityId == facilityId && s.IsDeleted == false);

            var serviceDtos = new List<ServiceDto>();

            foreach (var service in filteredServices)
            {
                var reviews = await _reviewRepository.GetReviewsByServiceIdAsync(service.Id);
                var averageRating = reviews.Any() ? reviews.Average(r => r.Rating) : 0;

                serviceDtos.Add(new ServiceDto
                {
                    Id = service.Id,
                    Name = service.Name,
                    Description = service.Description,
                    ImgUrl = service.ImgUrl,
                    Price = service.Price,
                    FacilityId = service.FacilityId,
                    IsDeleted = service.IsDeleted,
                    AverageRating = averageRating // Assuming you add this property to ServiceDto
                });
            }

            return serviceDtos;
        }

        public async Task AddServiceAsync(Service service, int airportId)
        {
            var facility = await _facilityRepository.GetFacilityAsync(service.FacilityId);

            if(facility.AirportId != airportId)
            {
                throw new UnauthorizedAccessException("You do not have access to this service");
            }

            await _serviceRepository.AddServiceAsync(service);
        }

        public async Task UpdateServiceAsync(Service service, int airportId)
        {
            var facility = await _facilityRepository.GetFacilityAsync(service.FacilityId);

            if (facility.AirportId != airportId)
            {
                throw new UnauthorizedAccessException("You do not have access to this service");
            }

            await _serviceRepository.UpdateServiceAsync(service);
        }

        public async Task DeleteServiceAsync(int id)
        {
            await _serviceRepository.DeleteServiceAsync(id);
        }
    }
}
