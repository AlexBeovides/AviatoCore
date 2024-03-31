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

        public ServiceService(IServiceRepository serviceRepository,
             IFacilityRepository facilityRepository)
        {
            _serviceRepository = serviceRepository;
            _facilityRepository = facilityRepository;
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
                Price = s.Price,
                FacilityId = s.FacilityId,
                IsDeleted = s.IsDeleted
            });

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
