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

namespace AviatoCore.Application.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IServiceRequestRepository _clientServicesRepository;

        public ServiceRequestService(IServiceRequestRepository clientServicesRepository)
        {
            _clientServicesRepository = clientServicesRepository;
        }
        public async Task<ServiceRequest> GetServiceRequestAsync(int id)
        {
            return await _clientServicesRepository.GetServiceRequestAsync(id);
        }
        public async Task AddServiceRequestAsync(ServiceRequest clientService)
        {
            await _clientServicesRepository.AddServiceRequestAsync(clientService);
        }

       
    }
}
