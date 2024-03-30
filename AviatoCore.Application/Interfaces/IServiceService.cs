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
        Task<Service> GetServiceAsync(int id);
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
    }
}
