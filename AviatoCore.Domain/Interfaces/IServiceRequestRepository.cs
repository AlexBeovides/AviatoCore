using AviatoCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AviatoCore.Domain.Interfaces
{
    public interface IServiceRequestRepository
    {
        Task AddServiceRequestAsync(ServiceRequest serviceRequest);
        Task<ServiceRequest> GetServiceRequestAsync(int id); // New method
    }
}
