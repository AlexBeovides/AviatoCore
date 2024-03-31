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
    public interface IServiceService
    {
        Task<Service> GetServiceAsync(int id, int airportId);
        Task<IEnumerable<ServiceDto>> GetAllServicesAsync(int airportId);
        Task AddServiceAsync(Service service, int airportId);
        Task UpdateServiceAsync(Service service, int airportId);
        Task DeleteServiceAsync(int id);
    }
}
