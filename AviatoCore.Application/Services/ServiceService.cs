using AviatoCore.Application.Interfaces;
using AviatoCore.Domain.Entities;
using AviatoCore.Domain.Interfaces;
using AviatoCore.Infrastructure;
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

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Service> GetServiceAsync(int id)
        {
            return await _serviceRepository.GetServiceAsync(id);
        }

        public async Task<IEnumerable<Service>> GetAllServicesAsync()
        {
            return await _serviceRepository.GetAllServicesAsync();
        }

        public async Task AddServiceAsync(Service service)
        {
            await _serviceRepository.AddServiceAsync(service);
        }

        public async Task UpdateServiceAsync(Service service)
        {
            await _serviceRepository.UpdateServiceAsync(service);
        }

        public async Task DeleteServiceAsync(int id)
        {
            await _serviceRepository.DeleteServiceAsync(id);
        }
    }
}
