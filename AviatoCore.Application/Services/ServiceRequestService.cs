using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using AviatoCore.Infrastructure.Interfaces;
using AviatoCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AviatoCore.Application.DTOs;
using AviatoCore.Infrastructure.Repositories;

namespace AviatoCore.Application.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IFacilityRepository _facilityRepository;

        public ServiceRequestService(IServiceRequestRepository serviceRequestRepository,
            IServiceRepository serviceRepository,
             IFacilityRepository facilityRepository)
        {
            _serviceRequestRepository = serviceRequestRepository;
            _serviceRepository = serviceRepository;
            _facilityRepository = facilityRepository;
        }

        public async Task<ServiceRequest> GetServiceRequestAsync(int id)
        {
            return await _serviceRequestRepository.GetServiceRequestAsync(id);
        }

        public async Task<IEnumerable<ServiceRequest>> GetServiceRequestsByAirportIdAsync(int airportId)
        {
            var facilities = await _facilityRepository.GetFacilitiesByAirportIdAsync(airportId);
            var facilityIds = facilities.Select(f => f.Id);

            var allServices = await _serviceRepository.GetAllServicesAsync();
            var serviceIds = allServices.Where(s => facilityIds.Contains(s.FacilityId)).Select(s => s.Id);

            var allServiceRequests = await _serviceRequestRepository.GetAllServiceRequestsAsync();
            var filteredServiceRequests = allServiceRequests.Where(sr => serviceIds.Contains(sr.ServiceId));

            var serviceRequests = new List<ServiceRequest>();

            foreach (var serviceRequest in filteredServiceRequests)
            {
                serviceRequests.Add(new ServiceRequest
                {
                    Id = serviceRequest.Id,
                    RequestedAt = serviceRequest.RequestedAt,
                    ClientId = serviceRequest.ClientId,
                    ServiceId = serviceRequest.ServiceId
                });
            }

            return serviceRequests;
        }

        public async Task AddServiceRequestAsync(ServiceRequest clientService)
        {
            await _serviceRequestRepository.AddServiceRequestAsync(clientService);
        }

       
    }
}
