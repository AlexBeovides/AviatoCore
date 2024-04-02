using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Infrastructure.Interfaces
{
    public interface IServiceRepository
    {
        Task<Service> GetServiceAsync(int id);
        Task<IEnumerable<Service>> GetAllServicesAsync();
        Task AddServiceAsync(Service service);
        Task UpdateServiceAsync(Service service);
        Task DeleteServiceAsync(int id);
    }
}
